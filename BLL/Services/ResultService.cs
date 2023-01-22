using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models.Result;
using BLL.Models.Value;
using DAL;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ResultService
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public ResultService(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ResultModel>> GetResults(GetResultsRequest request, CancellationToken token)
        {
            return await _db.Results.WithAverageIndexFilter(request.AverageIndexFrom, request.AverageIndexTo)
                .WithAverageTimeFilter(request.AverageTimeFrom, request.AverageTimeTo)
                .WithFirstOperationFilter(request.FirstOperationFrom, request.FirstOperationTo)
                .WithFileNameFilter(request.FileName).ProjectTo<ResultModel>(_mapper.ConfigurationProvider).AsNoTracking()
                .ToListAsync(token);
        }

        public static ResultModel GetResultModel(List<ValueModel> models)
        {
            return new ResultModel()
            {
                StringsAmount = models.Count,
                MedianaIndex = GetMedianaValues(models),
                AverageIndex = GetAverageIndexValues(models),
                AverageTime = GetAverageTimeValues(models),
                AllTimeInSeconds = GetAllTimeValues(models),
                MinimumIndex = GetMinimumIndexValues(models),
                MaximumIndex = GetMaximumIndexValues(models),
                FirstOperation = GetFirstOperationValues(models)
            };
        }

        public static double GetMedianaValues(List<ValueModel> values)
        {
            var models = values.OrderBy(x => x.Index).ToList();
            var amountModels = models.Count;
            if (amountModels % 2 != 0)
            {
                return models[amountModels / 2 + 1].Index;
            }
            return (models[amountModels / 2].Index + models[amountModels / 2 + 1].Index) / 2;
        }

        public static double GetAverageTimeValues(IEnumerable<ValueModel> models)
        {
            return models.Select(x => x.Time).Sum() / models.Count();
        }

        public static double GetAverageIndexValues(IEnumerable<ValueModel> models)
        {
            return models.Select(x=>x.Index).Sum() / models.Count();
        }

        public static double GetMinimumIndexValues(List<ValueModel> models)
        {
            double min = models[0].Index;
            foreach (var el in models)
            {
                if (el.Index < min) min = el.Index;
            }
            return min;
        }
        public static double GetMaximumIndexValues(List<ValueModel> models)
        {
            double max = 0;
            foreach (var el in models)
            {
                if (el.Index > max) max = el.Index;
            }
            return max;
        }

        public static DateTime GetFirstOperationValues(List<ValueModel> models)
        {
            DateTime min = models[0].Date;
            foreach (var el in models)
            {
                if (el.Date < min) min = el.Date;
            }
            return min;
        }
        public static DateTime GetLastOperationValues(List<ValueModel> models)
        {
            DateTime max = new DateTime(2000, 1, 1);
            foreach (var el in models)
            {
                if (el.Date > max) max = el.Date;
            }
            return max;
        }
        public static double GetAllTimeValues(List<ValueModel> models)
        {
            DateTime min = GetFirstOperationValues(models), max = GetLastOperationValues(models);
            long elapsedTicks = max.Ticks - min.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            return elapsedSpan.TotalSeconds;
        }

    }
}

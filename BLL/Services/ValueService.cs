using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Automapper.Profiles;
using BLL.Models.Value;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ValueService
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        public ValueService(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddValuesFromFile(Stream fileStream, string fileName)
        {
            var valueModels = await ParserService.ReadValuesFileAsync(fileStream);
            var fileDb = await _db.Files.FirstOrDefaultAsync(x => x.NameFile == fileName);
            if (fileDb != null) _db.Files.Remove(fileDb);
            var file = new DAL.Entities.File()
            {
                NameFile = fileName,
                Values = valueModels.Select(x => _mapper.Map<Value>(x)).ToList(),
                Result = _mapper.Map<Result>(ResultService.GetResultModelByValueModels(valueModels))
            };
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ValueModel>> GetValuesModelsByFileName(string fileName, CancellationToken token)
        {
            return await _db.Values.Where(x => x.File.NameFile == fileName)
                .ProjectTo<ValueModel>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync(token);
        }
    }
}

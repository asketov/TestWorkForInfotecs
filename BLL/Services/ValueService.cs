using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL;
using DAL.Entities;

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
            var file = new DAL.Entities.File()
            {
                NameFile = fileName,
                Values = valueModels.Select(x => _mapper.Map<Value>(x)).ToList(),
                Result = _mapper.Map<Result>(ResultService.GetResultModelByValueModels(valueModels))
            };
            _db.Files.Add(file);
            await _db.SaveChangesAsync();
        }
    }
}

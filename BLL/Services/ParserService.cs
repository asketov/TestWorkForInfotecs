using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Services
{
    public class ParserService
    {
        private readonly DataContext _db;

        public ParserService(DataContext db)
        {
            _db = db;
        }
        public void ReadValuesFile(Stream streamFile)
        {
            
        }
        public static async Task<string> ReadValuesFileAsync(Stream streamFile)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(streamFile))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using BLL.Models.Value;
using Common.Exceptions.Validate;
using Common.Helpers;


namespace BLL.Services
{
    public static class ParserService
    {
        public static async Task<List<ValueModel>> ReadValuesFileAsync(Stream streamFile)
        {
            List<ValueModel> models = new List<ValueModel>();
            using (var reader = new StreamReader(streamFile))
            {
                var str = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(str)) throw new ValidateFileException("Строк в файле должно быть больше 0" +
                                                                               "или у вас есть пустые строки в начале");
                while (!string.IsNullOrEmpty(str))
                {
                    if(models.Count > 10000) throw new ValidateFileException("Строк в файле должно быть меньше 10000");
                    var valueModel = str.GetValueModelFromStr();
                    valueModel.ValidateModel();
                    models.Add(valueModel);
                    str = await reader.ReadLineAsync();
                }
            }
            return models;
        }

        private static ValueModel GetValueModelFromStr(this string str)
        {
           var strMas = str.Split(';');
           return new ValueModel()
           {
               Date = DateTime.ParseExact(strMas[0], "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture),
               Time = Int64.Parse(strMas[1]),
               Index = Double.Parse(strMas[2])
           };
        }
    }
}

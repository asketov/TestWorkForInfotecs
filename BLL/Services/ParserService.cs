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
                if (str == "") throw new ValidateFileException("Строк в файле должно быть больше 0");
                while (str != "")
                {
                    if(models.Count > 10000) throw new ValidateFileException("Строк в файле должно быть меньше 10000");
                    var valueModel = GetValueModelFromStr((str!));
                    valueModel.ValidateModel();
                    models.Add(valueModel);
                    str = await reader.ReadLineAsync();
                }
            }
            return models;
        }

        private static ValueModel GetValueModelFromStr(string str)
        {
           var strMas = str.Split(';');
           return new ValueModel()
           {
               Date = DateTime.ParseExact(strMas[0], "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture),
               Time = Int32.Parse(strMas[1]),
               Index = Double.Parse(strMas[2])
           };
        }
    }
}

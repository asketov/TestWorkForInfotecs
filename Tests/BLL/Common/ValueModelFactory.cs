using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Value;

namespace Tests.BLL.Common
{
    public static class ValueModelFactory
    {
        public static List<ValueModel> GetValueModels()
        {
            return new List<ValueModel>
            {
                new()
                {
                    Date = DateTime.Today, Index = 2800.7, Time = 6743
                },
                new()
                {
                    Date = new DateTime(2016,1,1), Index = 2412.1, Time = 2800
                },
                new()
                {
                    Date = new DateTime(2015,12,11), Index = 2000.534, Time = 2000
                },
                new()
                {
                    Date = new DateTime(2019,7,5), Index = 2500.11, Time = 2500
                },
                new()
                {
                    Date = DateTime.Today, Index = 3000.8, Time = 3000
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Attributes;
using Microsoft.EntityFrameworkCore.Storage;

namespace BLL.Models.Value
{
    public class ValueModel
    {
        [ValueDate]
        public DateTime Date { get; set; }
        [Range(0,Int32.MaxValue)]
        public int Time { get; set; }
        [Range(0,Double.MaxValue)]
        public double Index { get; set; }
    }
}

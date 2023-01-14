using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace BLL.Models.Result
{
    public class GetResultsRequest
    {
        public string? FileName { get; set; }
        public double? AverageIndexFrom { get; set; }
        public double? AverageIndexTo { get; set; }
        public double? AverageTimeFrom { get; set; }
        public double? AverageTimeTo { get; set; }
        public DateTime? FirstOperationFrom { get; set; }
        public DateTime? FirstOperationTo { get; set; }

    }
}

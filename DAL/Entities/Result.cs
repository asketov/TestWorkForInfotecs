using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Result
    {
        public Guid Id { get; set; }
        public double AllTimeInSeconds { get; set; }
        public DateTime FirstOperation { get; set; }
        public double AverageTime { get; set; }
        public double AverageIndex { get; set; }
        public double MedianaIndex { get; set; }
        public double MaximumIndex { get; set; }
        public double MinimumIndex { get; set; }
        public int StringsAmount { get; set; }
        public Guid FileId { get; set; }
        public virtual File File { get; set; } = null!;
    }
}

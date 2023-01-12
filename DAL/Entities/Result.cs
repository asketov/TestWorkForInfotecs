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
        public int AllTime { get; set; }
        public DateTime FirstOperation { get; set; }
        public int AverageTime { get; set; }
        public double AverageIndex { get; set; }
        public double MedianaIndex { get; set; }
        public double MaximumIndex { get; set; }
        public double MinimumIndex { get; set; }
        public int StringsAmount { get; set; }
        public virtual Value Value { get; set; } = null!;
    }
}

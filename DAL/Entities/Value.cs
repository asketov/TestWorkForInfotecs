using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Value
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public double Index { get; set; }
        public virtual File File { get; set; } = null!;
    }
}

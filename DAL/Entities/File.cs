using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class File
    {
        public Guid Id { get; set; }
        public string NameFile { get; set; } = null!;
        public virtual ICollection<Value> Values { get; set; } = null!;
        public virtual Result Result { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernate_Example_3.Entities
{
    public class Project
    {        
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual double EstimatedHours { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

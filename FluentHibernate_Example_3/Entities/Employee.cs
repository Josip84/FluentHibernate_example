using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernate_Example_3.Entities
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Project> Projects { get; set; }

        public Employee()
        {
            Projects = new List<Project>();
        }

    }
}

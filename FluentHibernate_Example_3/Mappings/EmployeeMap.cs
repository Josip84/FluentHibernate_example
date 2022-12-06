using FluentHibernate_Example_3.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernate_Example_3.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            

            // This one is storing ID of Employee table to Project table field Id_emp
            HasMany(x => x.Projects)
                .Table("project")
                .KeyColumn("Id_emp")
                .Cascade.AllDeleteOrphan()
                .Not.KeyNullable();
                      
        }
    }
}

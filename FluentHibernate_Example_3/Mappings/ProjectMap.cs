using FluentHibernate_Example_3.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentHibernate_Example_3.Mappings
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.EstimatedHours);           
        }
    }
}

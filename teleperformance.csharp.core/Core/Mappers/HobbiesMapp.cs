using Core.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class HobbiesMapp : DommelEntityMap<Hobbies>
    {
        public HobbiesMapp()
        {
            ToTable("Hobbies");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Name).ToColumn("Name");
        }
    }
}

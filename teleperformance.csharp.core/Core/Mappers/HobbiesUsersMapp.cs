using Core.Entities;
using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class HobbiesUsersMapp : DommelEntityMap<HobbiesUsers>
    {
        public HobbiesUsersMapp()
        {
            ToTable("HobbiesUsers");
            Map(x => x.UserId).ToColumn("UserId").IsKey();
            Map(x => x.HobbieId).ToColumn("HobbieId").IsKey();
        }
    }
}

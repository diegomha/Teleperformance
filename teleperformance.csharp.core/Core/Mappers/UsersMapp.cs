using Core.Entities;
using Core.Mappers;
using Dapper.FluentMap.Dommel.Mapping;

namespace TCore.Mappers
{
    public class UsersMapp : DommelEntityMap<Users>
    {
        public UsersMapp()
        {
            ToTable("USERS");
            Map(x => x.Id).ToColumn("Id").IsKey();
            Map(x => x.Name).ToColumn("Name");
            Map(x => x.UserName).ToColumn("UserName");
            Map(x => x.PhoneNumber).ToColumn("PhoneNumber");
        }
    }
}
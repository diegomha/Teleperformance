using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using TCore.Mappers;

namespace Repository
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UsersMapp());
                config.ForDommel();
            });
        }
    }
}
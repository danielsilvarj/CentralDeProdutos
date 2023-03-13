namespace CentralDeProdutos.Services.Api.Setups
{
    public class AutoMapperSetup
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

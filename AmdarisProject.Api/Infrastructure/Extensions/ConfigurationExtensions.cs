using AmdarisProject.Api.Infrastructure.Configurations;

namespace AmdarisProject.Api.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static JwtAuthOptions ConfigureJwtAuthOptions(this IConfiguration configuration, IServiceCollection services)
        {
            var section = configuration.GetSection("JwtAuthOptions");
            services.Configure<JwtAuthOptions>(section);

            var authOptions = section.Get<JwtAuthOptions>();
            return authOptions;
        }

        public static void ConfigureFileManagerOptions(this IConfiguration configuration, IServiceCollection services)
        {
            var section = configuration.GetSection("FileManagerOptions");
            services.Configure<FileManagerOptions>(section);
        }
    }
}

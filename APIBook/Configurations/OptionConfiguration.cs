using APIBook.Options;

namespace APIBook.Configurations
{
	public static class OptionConfiguration
	{
		public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtOptions>(configuration.GetSection("JWT"));
		}
	}
}

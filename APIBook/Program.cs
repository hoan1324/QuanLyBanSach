
using APIBook.Configurations;
using ApiInfrastructure.Context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using Serilog;

namespace APIBook
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Host.UseSerilog((context, service, configuration) =>
			{
				configuration
				.WriteTo.Console()
				.WriteTo.File("/Logs/log-.txt", rollingInterval: RollingInterval.Day);
			});
			builder.Services.Configure<FormOptions>(options =>
			{
				options.MultipartBodyLengthLimit = 524288000; // Set to 500 MB (or any size you need)
			});
			// Add cors
			const string corsKey = "allowCORS";
			string[] origins = builder.Configuration["origins:domains"].Split(",");
			builder.Services.AddCors(options =>
			{
				options.AddPolicy(name: corsKey,
								  builder =>
								  {
									  builder
									  .WithOrigins(origins)
									  .AllowAnyHeader()
									  .AllowAnyMethod()
									  .AllowCredentials();
								  });
			});

			// Add services to the container.
			builder.Services.AddOptions(builder.Configuration);
			builder.Services.AddServices(builder.Configuration);

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			

			builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id="Bearer"
				}
			},
			new string[]{}
		}
	});
			});
			var app = builder.Build();

			app.UseCors(corsKey);

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				DbInitalizer.Initialize(services);


			}
			//cho phép các domain khác gọi api từ local


			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.Use(async (context, next) =>
			{
				context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 524288000; // Set to 500 MB
				await next.Invoke();
			});
			app.MapControllers();

			app.Run();
		}
	}
}



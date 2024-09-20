using HTTPswagerTEST.Models;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HTTPswagerTEST
{



	public class Program
	{

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddDbContext<ToBuyItemsContext>(options => 
					options.UseInMemoryDatabase("ToBuyItemss"));


			

			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Список покупок",
					Description = "Простой список покупок с возможностью добавлять товар, изменять его количество, менять статус ну и с функцией удаления записи",

				});

				var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}



			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();


			app.Run();
		}

	//	public static IHostBuilder CreateHostBuilder(string[] args) =>
	//Host.CreateDefaultBuilder(args)
	//	.ConfigureWebHostDefaults(webBuilder =>
	//	{
	//		webBuilder.UseStartup<Startup>();
	//	});
	}
}

using HTTPswagerTEST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace HTTPswagerTEST
{
	public class Startup
	{
		public void ConfigureService(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen();

		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();

			app.UseHttpsRedirection();


			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

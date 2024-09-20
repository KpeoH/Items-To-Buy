using Microsoft.EntityFrameworkCore;

namespace HTTPswagerTEST.Models
{
	public class ToBuyItemsContext : DbContext
	{
		public ToBuyItemsContext(DbContextOptions<ToBuyItemsContext> options)
			: base(options)
		{
		}

		public DbSet<ToBuyItems> ToBuyItems { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	string curDir = Directory.GetCurrentDirectory();
		//	optionsBuilder.UseSqlite($"Data source={curDir}\\data.db");
		//}
	}


}


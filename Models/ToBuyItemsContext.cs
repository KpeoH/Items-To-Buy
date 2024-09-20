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

	}


}


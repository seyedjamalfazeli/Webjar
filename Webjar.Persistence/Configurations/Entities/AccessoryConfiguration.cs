using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Webjar.Domain;

namespace Webjar.Persistence.Configurations.Entities
{
	internal class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
	{
		public void Configure(EntityTypeBuilder<Accessory> builder)
		{
			builder.HasData(new Accessory
			{
				AccessoryId = 1,
				Title = "بسته بندی ویژه هدیه",
				Amount = 15000,
			},
			new Accessory
			{
				AccessoryId = 2,
				Title = "کاور مخصوص لباس",
				Amount = 30000,
			});
		}
	}
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Webjar.Domain;

namespace Webjar.Persistence.Configurations.Entities
{
	internal class ColorVariableConfiguration : IEntityTypeConfiguration<ColorVariable>
	{
		public void Configure(EntityTypeBuilder<ColorVariable> builder)
		{
			builder.HasData(new ColorVariable
			{
				ColorVariableId = 1,
				Title = "قرمز",
				HexCode = "FF0000",
				DateCreated = DateTime.Now,
				LastModifiedDate = DateTime.Now,
			},
			new ColorVariable
			{
				ColorVariableId = 2,
				Title = "سبز",
				HexCode = "00FF00",
				DateCreated = DateTime.Now,
				LastModifiedDate = DateTime.Now,
			},
			new ColorVariable
			{
				ColorVariableId = 3,
				Title = "آبی",
				HexCode = "0000FF",
				DateCreated = DateTime.Now,
				LastModifiedDate = DateTime.Now,
			});
		}
	}
}

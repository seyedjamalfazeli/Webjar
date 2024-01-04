using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Webjar.Domain;

namespace Webjar.Persistence.Configurations.Entities
{
	public class SizeVariableConfiguration : IEntityTypeConfiguration<SizeVariable>
	{
		public void Configure(EntityTypeBuilder<SizeVariable> builder)
		{
			builder.HasData(new SizeVariable
			{
				SizeVariableId = 1,
				Title = "M",
			},
			new SizeVariable
			{
				SizeVariableId = 2,
				Title = "L",
			},
			new SizeVariable
			{
				SizeVariableId = 3,
				Title = "XL",
			});
		}
	}
}

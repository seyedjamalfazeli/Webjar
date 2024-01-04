namespace Webjar.Domain.Common
{
	public abstract class BaseDomainEntity
	{
		public DateTime DateCreated { get; set; }
		public String? CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public String? LastModifiedBy { get; set; }
	}
}

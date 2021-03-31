namespace FarmerAndPartnersEF.EF
{
    using FarmerAndPartnersModels;
    using System.Data.Entity;

    public partial class FarmerAndPartnersEntities : DbContext
    {
        public FarmerAndPartnersEntities()
            : base("name=FarmerAndPartnersEntities") { }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ContractStatus> ContractStatuses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractStatus>()
                .HasMany(c => c.Companies)
                .WithRequired(c => c.ContractStatus)
                .WillCascadeOnDelete(false);
        }
    }
}

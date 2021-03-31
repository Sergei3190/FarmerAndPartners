namespace FarmerAndPartnersEF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    ContractStatusId = c.Int(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractStatus", t => t.ContractStatusId, cascadeDelete: true)
                .Index(t => t.ContractStatusId);

            CreateTable(
                "dbo.ContractStatus",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Definition = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Login = c.String(nullable: false, maxLength: 50),
                    Password = c.String(nullable: false, maxLength: 50),
                    CompanyId = c.Int(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "ContractStatusId", "dbo.ContractStatus");
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "ContractStatusId" });
            DropTable("dbo.Users");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.Companies");
        }
    }
}

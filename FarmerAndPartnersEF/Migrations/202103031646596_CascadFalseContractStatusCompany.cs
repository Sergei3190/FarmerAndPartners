namespace FarmerAndPartnersEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadFalseContractStatusCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "ContractStatusId", "dbo.ContractStatus");
            AddForeignKey("dbo.Companies", "ContractStatusId", "dbo.ContractStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ContractStatusId", "dbo.ContractStatus");
            AddForeignKey("dbo.Companies", "ContractStatusId", "dbo.ContractStatus", "Id", cascadeDelete: true);
        }
    }
}

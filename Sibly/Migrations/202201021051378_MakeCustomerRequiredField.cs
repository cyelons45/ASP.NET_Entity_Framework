namespace Sibly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCustomerRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}

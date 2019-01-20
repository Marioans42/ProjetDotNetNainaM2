namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationModeles1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Livres", "dapparution", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Livres", "dapparution", c => c.DateTime(nullable: false));
        }
    }
}

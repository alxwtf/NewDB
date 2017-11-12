namespace NewDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        industry = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        site = c.String(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Contacts", new[] { "CompanyId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Companies");
        }
    }
}

namespace Abstergo.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StringModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Value = c.String(),
                        Lang = c.String(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserModels", "UpdateUser", c => c.String());
            AddColumn("dbo.UserModels", "UpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserModels", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModels", "IsActive");
            DropColumn("dbo.UserModels", "UpdateDate");
            DropColumn("dbo.UserModels", "UpdateUser");
            DropTable("dbo.StringModels");
        }
    }
}

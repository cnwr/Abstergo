namespace Abstergo.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ver3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StringModels");
            DropTable("dbo.UserModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
    }
}

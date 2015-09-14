namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagdescricaoisunique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tag", "Descricao", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tag", new[] { "Descricao" });
        }
    }
}

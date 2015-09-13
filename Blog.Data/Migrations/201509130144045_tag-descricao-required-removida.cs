namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagdescricaorequiredremovida : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tag", "Descricao", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tag", "Descricao", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
    }
}

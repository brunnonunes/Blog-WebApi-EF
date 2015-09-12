namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 250, unicode: false),
                        Corpo = c.String(maxLength: 1000, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "PerfilId", "dbo.Perfil");
            DropIndex("dbo.Usuario", new[] { "PerfilId" });
            DropIndex("dbo.Post", new[] { "UsuarioId" });
            DropTable("dbo.Tag");
            DropTable("dbo.Usuario");
            DropTable("dbo.Post");
            DropTable("dbo.Perfil");
        }
    }
}

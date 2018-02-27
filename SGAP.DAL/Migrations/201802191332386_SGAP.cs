namespace SGAP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SGAP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DBO.TBL_PERFIL",
                c => new
                    {
                        iCodPerfil = c.Int(nullable: false, identity: true),
                        iCodAcesso = c.Int(nullable: false),
                        strDescricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.iCodPerfil)
                .ForeignKey("DBO.TBL_ACESSO", t => t.iCodAcesso)
                .Index(t => t.iCodAcesso);
            
            CreateTable(
                "DBO.TBL_ACESSO",
                c => new
                    {
                        iCodAcesso = c.Int(nullable: false, identity: true),
                        strDescricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.iCodAcesso);
            
            CreateTable(
                "DBO.TBL_PESSOA",
                c => new
                    {
                        iCodPessoa = c.Int(nullable: false, identity: true),
                        iCodPessoaPerfil = c.Int(nullable: false),
                        strNomePessoa = c.String(nullable: false),
                        strUsuario = c.String(nullable: false),
                        strSenha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.iCodPessoa)
                .ForeignKey("DBO.TBL_PERFIL", t => t.iCodPessoaPerfil)
                .Index(t => t.iCodPessoaPerfil);
            
        }
        
        public override void Down()
        {
            DropForeignKey("DBO.TBL_PESSOA", "iCodPessoaPerfil", "DBO.TBL_PERFIL");
            DropForeignKey("DBO.TBL_PERFIL", "iCodAcesso", "DBO.TBL_ACESSO");
            DropIndex("DBO.TBL_PESSOA", new[] { "iCodPessoaPerfil" });
            DropIndex("DBO.TBL_PERFIL", new[] { "iCodAcesso" });
            DropTable("DBO.TBL_PESSOA");
            DropTable("DBO.TBL_ACESSO");
            DropTable("DBO.TBL_PERFIL");
        }
    }
}

namespace sistema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatas",
                c => new
                    {
                        pkCandidata = c.Int(nullable: false, identity: true),
                        sNombreCompleto = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        dFechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        sDescripcion = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sCorreoElectronico = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sCurp = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sNivelEstudios = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        dAnioConvocatoria = c.DateTime(nullable: false, precision: 0),
                        sFotoCandidata = c.String(nullable: false, unicode: false),
                        iRanking = c.Int(nullable: false),
                        bStatus = c.Boolean(nullable: false),
                        Municipios_pkMunicipio = c.Int(),
                        Usuarios_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkCandidata)
                .ForeignKey("dbo.Municipios", t => t.Municipios_pkMunicipio)
                .ForeignKey("dbo.Usuarios", t => t.Usuarios_pkUsuario)
                .Index(t => t.Municipios_pkMunicipio)
                .Index(t => t.Usuarios_pkUsuario);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        pkMunicipio = c.Int(nullable: false, identity: true),
                        sNombreMunicipio = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sDescripcion = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkMunicipio);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        pkUsuario = c.Int(nullable: false, identity: true),
                        sNombreCompleto = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        Cuenta = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sContrasena = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                        Roles_pkRol = c.Int(),
                    })
                .PrimaryKey(t => t.pkUsuario)
                .ForeignKey("dbo.Roles", t => t.Roles_pkRol)
                .Index(t => t.Roles_pkRol);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        pkRol = c.Int(nullable: false, identity: true),
                        sNombreRol = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sDescripcion = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.pkRol);
            
            CreateTable(
                "dbo.PermisosNegadosPorRoles",
                c => new
                    {
                        pkPermisosNegadosPorRoles = c.Int(nullable: false, identity: true),
                        Permisos_pkPermiso = c.Int(),
                        Roles_pkRol = c.Int(),
                    })
                .PrimaryKey(t => t.pkPermisosNegadosPorRoles)
                .ForeignKey("dbo.Permisos", t => t.Permisos_pkPermiso)
                .ForeignKey("dbo.Roles", t => t.Roles_pkRol)
                .Index(t => t.Permisos_pkPermiso)
                .Index(t => t.Roles_pkRol);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        sDescripcion = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.pkPermiso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Roles_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosPorRoles", "Roles_pkRol", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosPorRoles", "Permisos_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Candidatas", "Usuarios_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Candidatas", "Municipios_pkMunicipio", "dbo.Municipios");
            DropIndex("dbo.PermisosNegadosPorRoles", new[] { "Roles_pkRol" });
            DropIndex("dbo.PermisosNegadosPorRoles", new[] { "Permisos_pkPermiso" });
            DropIndex("dbo.Usuarios", new[] { "Roles_pkRol" });
            DropIndex("dbo.Candidatas", new[] { "Usuarios_pkUsuario" });
            DropIndex("dbo.Candidatas", new[] { "Municipios_pkMunicipio" });
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegadosPorRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Municipios");
            DropTable("dbo.Candidatas");
        }
    }
}

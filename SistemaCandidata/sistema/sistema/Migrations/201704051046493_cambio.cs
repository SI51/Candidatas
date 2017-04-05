namespace sistema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Municipios", "sLogotipo", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Municipios", "sLogotipo");
        }
    }
}

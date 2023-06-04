namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contents", name: "Writer_WriterID", newName: "WriterID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Contents", name: "WriterID", newName: "Writer_WriterID");
        }
    }
}

namespace webTimPhong.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ROOM", "IsConfirm", c => c.Boolean());
            DropColumn("dbo.ROOM", "IsActive");
            DropColumn("dbo.ROOM", "ConfirmStatus");
            DropColumn("dbo.ROOM", "IsAvaiable");
            DropColumn("dbo.ROOMDetail", "FreeTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ROOMDetail", "FreeTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.ROOM", "IsAvaiable", c => c.Boolean(nullable: false));
            AddColumn("dbo.ROOM", "ConfirmStatus", c => c.Int(nullable: false));
            AddColumn("dbo.ROOM", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ROOM", "IsConfirm", c => c.Boolean(nullable: false));
        }
    }
}

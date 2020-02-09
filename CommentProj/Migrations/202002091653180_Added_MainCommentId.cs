namespace CommentProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_MainCommentId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "MainCommentId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "MainCommentId");
        }
    }
}

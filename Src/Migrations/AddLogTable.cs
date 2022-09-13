using FluentMigrator;

namespace WebCoreTest.Migrations
{
    [Migration(20220912001)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString(255);
        }

        public override void Down()
        {
            Delete.Table("Log");
        }
    }
}

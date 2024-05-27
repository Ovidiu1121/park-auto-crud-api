using FluentMigrator;

namespace ParkAutoCrudApi.Data.Migrations
{
    [Migration(2305202411)]
    public class TestMigrate: Migration
    {
        public override void Up()
        {
            Execute.Script(@"./Data/Scripts/data.sql");
        }
        public override void Down()
        {

        }
    }
}

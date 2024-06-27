using FluentMigrator;

namespace ParkAutoCrudApi.Data.Migrations
{
    [Migration(23052024)]
    public class CreateSchema: Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {

            Create.Table("carParking")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("brand").AsString(128).NotNullable()
                .WithColumn("price").AsInt32().NotNullable()
                .WithColumn("horse_power").AsInt32().NotNullable()
                .WithColumn("fabrication_year").AsInt32().NotNullable();

        }
    }
}

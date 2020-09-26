namespace LAPTOPMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laptops",
                c => new
                {
                    id = c.String(nullable: false, maxLength: 30),
                    name = c.String(),
                    price = c.Int(nullable: false),
                    cpu = c.String(),
                    ram = c.Int(nullable: false),
                    storage = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id);
        }

        public override void Down()
        {
            DropTable("dbo.Laptops");
        }
    }
}
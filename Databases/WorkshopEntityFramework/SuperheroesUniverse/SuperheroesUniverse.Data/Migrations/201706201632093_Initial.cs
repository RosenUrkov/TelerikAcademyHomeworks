namespace SuperheroesUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Planet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.Planet_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Planet_Id);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Fractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Alignment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        SecretIdentity = c.String(nullable: false, maxLength: 20),
                        Alignment = c.Int(nullable: false),
                        Story = c.String(nullable: false, unicode: false, storeType: "text"),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.SecretIdentity, unique: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Powers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipType = c.Int(nullable: false),
                        FirstHero_Id = c.Int(),
                        SecondHero_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Superheroes", t => t.FirstHero_Id)
                .ForeignKey("dbo.Superheroes", t => t.SecondHero_Id)
                .Index(t => t.FirstHero_Id)
                .Index(t => t.SecondHero_Id);
            
            CreateTable(
                "dbo.SuperheroFractions",
                c => new
                    {
                        Superhero_Id = c.Int(nullable: false),
                        Fraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Superhero_Id, t.Fraction_Id })
                .ForeignKey("dbo.Superheroes", t => t.Superhero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fractions", t => t.Fraction_Id, cascadeDelete: true)
                .Index(t => t.Superhero_Id)
                .Index(t => t.Fraction_Id);
            
            CreateTable(
                "dbo.PowerSuperheroes",
                c => new
                    {
                        Power_Id = c.Int(nullable: false),
                        Superhero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Power_Id, t.Superhero_Id })
                .ForeignKey("dbo.Powers", t => t.Power_Id, cascadeDelete: true)
                .ForeignKey("dbo.Superheroes", t => t.Superhero_Id, cascadeDelete: true)
                .Index(t => t.Power_Id)
                .Index(t => t.Superhero_Id);
            
            CreateTable(
                "dbo.FractionPlanets",
                c => new
                    {
                        Fraction_Id = c.Int(nullable: false),
                        Planet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fraction_Id, t.Planet_Id })
                .ForeignKey("dbo.Fractions", t => t.Fraction_Id, cascadeDelete: true)
                .ForeignKey("dbo.Planets", t => t.Planet_Id, cascadeDelete: true)
                .Index(t => t.Fraction_Id)
                .Index(t => t.Planet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "SecondHero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.Relationships", "FirstHero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.FractionPlanets", "Planet_Id", "dbo.Planets");
            DropForeignKey("dbo.FractionPlanets", "Fraction_Id", "dbo.Fractions");
            DropForeignKey("dbo.PowerSuperheroes", "Superhero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.PowerSuperheroes", "Power_Id", "dbo.Powers");
            DropForeignKey("dbo.SuperheroFractions", "Fraction_Id", "dbo.Fractions");
            DropForeignKey("dbo.SuperheroFractions", "Superhero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.Superheroes", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Countries", "Planet_Id", "dbo.Planets");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.FractionPlanets", new[] { "Planet_Id" });
            DropIndex("dbo.FractionPlanets", new[] { "Fraction_Id" });
            DropIndex("dbo.PowerSuperheroes", new[] { "Superhero_Id" });
            DropIndex("dbo.PowerSuperheroes", new[] { "Power_Id" });
            DropIndex("dbo.SuperheroFractions", new[] { "Fraction_Id" });
            DropIndex("dbo.SuperheroFractions", new[] { "Superhero_Id" });
            DropIndex("dbo.Relationships", new[] { "SecondHero_Id" });
            DropIndex("dbo.Relationships", new[] { "FirstHero_Id" });
            DropIndex("dbo.Powers", new[] { "Name" });
            DropIndex("dbo.Superheroes", new[] { "City_Id" });
            DropIndex("dbo.Superheroes", new[] { "SecretIdentity" });
            DropIndex("dbo.Fractions", new[] { "Name" });
            DropIndex("dbo.Planets", new[] { "Name" });
            DropIndex("dbo.Countries", new[] { "Planet_Id" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropTable("dbo.FractionPlanets");
            DropTable("dbo.PowerSuperheroes");
            DropTable("dbo.SuperheroFractions");
            DropTable("dbo.Relationships");
            DropTable("dbo.Powers");
            DropTable("dbo.Superheroes");
            DropTable("dbo.Fractions");
            DropTable("dbo.Planets");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}

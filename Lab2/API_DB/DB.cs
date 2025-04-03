using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace API;

public class PokemonRow
{
    [Key]
    public int Id {get; set;}
    public string Name { get; set; }
    public int BaseExperience { get; set; }
    public int Height { get; set; }
    public List<string> Abilities { get; set; }
    public int TypeId {get; set;}
    
    [ForeignKey("TypeId")]
    public TypeRow Type { get; set; }
    
    public override string ToString()
    {
        return $"{char.ToUpper(Name[0]) + Name.Substring(1)} [ {string.Join("",Abilities.Select(a => "" + char.ToUpper(a[0]) + a.Substring(1) + " "))}]" +
               $" {Type?.Name}";

    }
}

public class TypeRow
{
    [Key]
    public int Id {get; set;}
    public string Name { get; set; }
    public  List<string> Counters { get; set; }
    
    public IList<PokemonRow> Pokemons { get; set; }
    public override string ToString()
    {
        return $"Type: {Name}\nCounters : {string.Join("",Counters.Select(a => a + " "))}";
    }
}

public class DB : DbContext
{
    public DbSet<PokemonRow> Pokemons { get; set; }
    public DbSet<TypeRow> Types { get; set; }
    private string dbPath; 
    public DB(string dbPath)
    {
        this.dbPath = dbPath;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(@$"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokemonRow>()
            .HasOne(p => p.Type)
            .WithMany(t => t.Pokemons)
            .HasForeignKey(p => p.TypeId);
        
        modelBuilder.Entity<TypeRow>().HasData(
            new TypeRow()
            {
                Id = 1,
                Name = "electricity",
                Counters = new List<string>(["water", "earth"])
            },

            new TypeRow()
            {
                Id = 2,
                Name = "fire",
                Counters = new List<string>(["water", "void"])
            },
            new TypeRow()
            {
                Id = 3,
                Name = "nature",
                Counters = new List<string>(["fire", "earth"])
            });
        
        modelBuilder.Entity<PokemonRow>().HasData(
            new PokemonRow()
            {
                Id = 1,
                Name = "pikachu",
                BaseExperience = 112,
                Height = 4,
                Abilities = new List<string>
                {
                    "static", "lightning-rod"
                },
                TypeId = 1
            },

            new PokemonRow()
            {
                Id = 2,
                Name = "charmander",
                BaseExperience = 240,
                Height = 17,
                Abilities = new List<string>
                {
                    "blaze", "solar-power"
                },
                TypeId = 2
            },

            new PokemonRow()
            {
                Id = 3,
                Name = "bulbasaur",
                BaseExperience = 64,
                Height = 7,
                Abilities = new List<string>
                {
                    "overgrow", "chlorophyll"
                },
                TypeId = 3
            });
        
    }
    
}
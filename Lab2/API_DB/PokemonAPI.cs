using System.Text.Json;
using System.Text.Json.Serialization;
namespace API;

public class AbilityInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

}

public class AbilityEntry
{
    [JsonPropertyName("ability")]
    public AbilityInfo Ability { get; set; }

}


public class Pokemon
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }
    
    [JsonPropertyName("height")]
    public int Height { get; set; }
    
    [JsonPropertyName("abilities")]
    public List<AbilityEntry> Abilities { get; set; }

    public override string ToString()
    {

        return $"NAME: {char.ToUpper(Name[0]) + Name.Substring(1)}\nHEIGHT: {(float)Height/10}m\nBASE EXPERIENCE: {BaseExperience} exp\nABILITIES : [ {string.Join("",Abilities.Select(a => "" + char.ToUpper(a.Ability.Name[0]) + a.Ability.Name.Substring(1) + " "))}]";
    }
    
}

public class PokemonAPI
{
    public HttpClient client;

    public async Task<Pokemon> GetPokemon(string pokemonName)
    {
        client = new HttpClient();
        string response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
        return JsonSerializer.Deserialize<Pokemon>(response)!;
    }
}
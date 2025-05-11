using System.Text;
using API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MAUI;
public partial class MainPage : ContentPage
{
    private PokemonAPI api;
    private DB db;
    private Pokemon? selectedPokemon;
    public MainPage()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PokemonDB.db");
        InitializeComponent();
        api = new PokemonAPI();
        db = new DB(dbPath);
        AddToCollection.IsEnabled = false;
        RemoveFromCollection.IsVisible = false;
        CollectionLabel.IsVisible = false;
    }

    private void DisplayList()
    {
        List<PokemonRow> pokemonNames = new List<PokemonRow>();
    
        foreach (var pokemon in db.Pokemons)
        {
           pokemonNames.Add(pokemon);
           pokemon.Type = db.Types.Where(type => type.Id.Equals(pokemon.TypeId)).First();
        }
    
        PokemonList.ItemsSource = pokemonNames;
        RemoveFromCollection.IsVisible = true;
        CollectionLabel.IsVisible = true;
    }
    

    private async void ApiCallButton_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var pokemon = PokemonNameEntry.Text;

            selectedPokemon = await api.GetPokemon(pokemon);

            PokemonLabel.Text = selectedPokemon.ToString();

            AddToCollection.Text = "Add to Collection";
            AddToCollection.IsEnabled = true;
        }
        catch (Exception ex)
        {
            PokemonLabel.Text = string.Empty;
            selectedPokemon = null;
        }
    }

    private void AddToCollection_OnClicked(object? sender, EventArgs e)
    {
        
        if (selectedPokemon == null)
            return;
        var abilities = new List<string>();
        
        selectedPokemon.Abilities.ForEach(a => abilities.Add(a.Ability.Name));
        Random random = new Random();
        db.Pokemons.Add(new PokemonRow()
        {
            Name = selectedPokemon.Name,
            BaseExperience = selectedPokemon.BaseExperience,
            Height = selectedPokemon.Height,
            Abilities = abilities,
            TypeId = random.Next(1, 4),
        });
        db.SaveChanges();
        AddToCollection.IsEnabled = false;
        AddToCollection.Text = "Added to Collection";
        DisplayList();
    }

    private void DisplayCollection_OnClicked(object? sender, EventArgs e)
    {
        DisplayList();
    }

    private void RemoveFromCollection_OnClicked(object? sender, EventArgs e)
    {
        var selectedPokemon = PokemonList.SelectedItem as PokemonRow;
        db.Pokemons.Remove(selectedPokemon!);
        db.SaveChanges();
        DisplayList();
    }
}
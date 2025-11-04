using TMPro;
using UnityEngine;

public class PokemonToShow : MonoBehaviour
{
    public TextMeshProUGUI pokemonName;

    public void NewPokemon()
    {
        Pokemon pokemon = PokeApi.PokemonFetch();
        pokemonName.text = pokemon.name;
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using Random = UnityEngine.Random;

public class PokemonToShow : MonoBehaviour
{
    public RawImage pokemonSprite;
    public TextMeshProUGUI pokemonName;
    public GameObject menuToClose;
    public bool player;
    
    

    public void NewPokemon()
    {
        StartCoroutine(LoadSprite());
   
    }
    private IEnumerator LoadSprite()
    {
        int id = Random.Range(1, 152);
        yield return PokeApi.PokemonFetch(id);
        
        Pokemon pokemon = PokeApi.pokemon;
        pokemonName.text = pokemon.name;
        string pokemonposition = String.Empty;
        if (player)
        {
            pokemonposition = pokemon.sprites.back_default;
        }
        else
        {
            pokemonposition = pokemon.sprites.front_default;
        }
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(pokemonposition);
   
        yield return request.SendWebRequest(); 

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Erro ao carregar sprite: " + request.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            texture.filterMode = FilterMode.Point;
            pokemonSprite.texture = texture;
            

        }
        menuToClose.SetActive(false);
    }
}

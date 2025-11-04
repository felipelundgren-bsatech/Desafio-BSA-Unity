using UnityEngine;
using System.Net;
using System.IO;

public static class PokeApi
{
    public static Pokemon PokemonFetch()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pokeapi.co/api/v2/pokemon/ditto");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string Json = reader.ReadToEnd();
        return JsonUtility.FromJson<Pokemon>(Json);
    }
}
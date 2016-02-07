using UnityEngine;
using System.Collections;

public class MovieScript : MonoBehaviour
{

    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)r.material.mainTexture;
        movie.Play();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("Level2");
        }
    }
}
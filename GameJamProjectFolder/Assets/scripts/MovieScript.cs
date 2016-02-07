using UnityEngine;
using System.Collections;

public class MovieScript : MonoBehaviour
{

    public MovieTexture MovieTexture;

    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = MovieTexture;
    }
}

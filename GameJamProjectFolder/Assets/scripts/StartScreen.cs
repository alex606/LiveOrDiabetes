using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour
{
    public string FirstLevel;

    void Update ()
    {
        if(!Input.GetMouseButtonDown(0))
        {
            return;
        }
        Application.LoadLevel(FirstLevel);
	}
}

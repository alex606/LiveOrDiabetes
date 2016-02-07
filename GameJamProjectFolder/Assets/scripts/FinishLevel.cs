using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {


    public string LevelName;
    public bool RequireKillAll = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Player>() == null)
        {
            return;
        }
        if(!RequireKillAll || GetComponent<LevelManager>().EnemiesRemaining == 0)
            LevelManager.Instance.GoToNextLevel(LevelName);
    }
}

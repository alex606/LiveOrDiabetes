using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameHud : MonoBehaviour
{
    public void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        {
            GUILayout.BeginVertical();
            {
                var time = GetComponent<LevelManager>().RunningTime;
                GUILayout.Label("Game Time : " + string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds));
                GUILayout.Label("Number of Deaths : " + GetComponent<LevelManager>().DeathCount);
                GUILayout.Label("Carb Enemies Left : " + GetComponent<LevelManager>().EnemiesRemaining);

            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }
}
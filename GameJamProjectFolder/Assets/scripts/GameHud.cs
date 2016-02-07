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
                GUILayout.Label(string.Format("{0:0}:{1:00}", time.Minutes, time.Seconds));
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }
}
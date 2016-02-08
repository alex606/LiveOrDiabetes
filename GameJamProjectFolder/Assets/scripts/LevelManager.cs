using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public Player Player { get; private set; }
    public CameraController Camera { get; private set; }

    private List<LevelStart> _levelstart;
    private int _currentLevelStartIndex;

    public LevelStart DebugSpawn;

    public void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        _levelstart = FindObjectsOfType<LevelStart>().OrderBy(t => t.transform.position.x).ToList();
        _currentLevelStartIndex = _levelstart.Count > 0 ? 0 : -1;

        Player = FindObjectOfType<Player>();
        Camera = FindObjectOfType<CameraController>();

#if UNITY_EDITOR
        if (DebugSpawn != null)
            DebugSpawn.SpawnPlayer(Player);
        else if (_currentLevelStartIndex != -1)
            _levelstart[_currentLevelStartIndex].SpawnPlayer(Player);
#else
        if(_curentLevelStartIndex != -1)
           _levelstart[_currentLevelStartIndex].SpawnPlayer(Player);
#endif
    }

    public void Update()
    {
        var isAtLastLevelStart = _currentLevelStartIndex + 1 >= _levelstart.Count;
        if (isAtLastLevelStart)
            return;

        var distanceToNextCheckPoint = _levelstart[_currentLevelStartIndex + 1].transform.position.x - Player.transform.position.x;

        if (distanceToNextCheckPoint >= 0)
            return;
        //_levelstart[_currentLevelStartIndex].PlayerLeftCheckpoint();
        //_currentLevelStartIndex++;
        //_levelstart[_currentLevelStartIndex].PlayerHitCheckpoint();
        
        //time points
    }

    public void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }


    private IEnumerator KillPlayerCo()
    {
        Player.Kill();
        Camera.IsFollowing = false;
        yield return new WaitForSeconds(2f);

        Camera.IsFollowing = true;
        if (_currentLevelStartIndex != -1)
            _levelstart[_currentLevelStartIndex].SpawnPlayer(Player);

        //points

    }
}


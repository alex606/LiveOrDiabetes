using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
    public class LevelStart : MonoBehaviour
    {

        public void Start()
        {

        }

        //public void PlayerHitCheckpoint()
        //{

        //}

        //private IEnumerator PlayerHitCheckpointCo(int bonus)
        //{
        //    yield break;
        //}

        //public void PlayerLeftCheckpoint()
        //{

        //}

        public void SpawnPlayer(Player player)
        {
            player.RespawnAt(transform);
        }

        public void AssignObjectToStart()
        {

        }
    }


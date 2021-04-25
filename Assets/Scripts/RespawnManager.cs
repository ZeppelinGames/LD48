using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform player;
    public ResetLevel rsLvl;
    public static RespawnManager instance;

    private Vector3 spawnPosition;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Respawn()
    {
        player.transform.position = spawnPosition;
        rsLvl.ResetLVL(); 
    }

    public void SetSpawnPoint(Vector3 spawnPos)
    {
        spawnPosition = spawnPos;
    }

    public void SetSpawnPos(Transform spawnPos)
    {
        spawnPosition = spawnPos.position;
    }
}

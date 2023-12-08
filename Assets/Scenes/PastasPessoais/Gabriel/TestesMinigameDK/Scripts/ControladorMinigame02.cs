using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ControladorMinigame02 : MonoBehaviour
{
    public float timer;
    public float timerMax;
    public float timeToSpawn;
    private bool spawnLimit;
    public GameObject obstaculo;
    public GameObject spawnPoint;
    private Vector3 spawnLocation;

    void Update()
    {
        spawnLocation = spawnPoint.transform.position;
        timer += Time.deltaTime;
        if (timer >= timerMax) { timer = 0; spawnLimit = false; }
        if (timer>=timeToSpawn && spawnLimit==false) { Instantiate(obstaculo, spawnLocation, Quaternion.identity); spawnLimit = true; }
       


    }
}

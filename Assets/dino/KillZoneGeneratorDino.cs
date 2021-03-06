﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneGeneratorDino : MonoBehaviour
{

    [SerializeField] private GameObject KillZone = null;
    private List<GameObject> KillZones = new List<GameObject>();
    public float maxTime = 10;
    public float timerStart = 0;
    private float timer = 0;
    // Start is called before the first frame update

    GameObject CreateKillZone()
    {
        GameObject newKillZone = Instantiate(KillZone);
        newKillZone.transform.position = new Vector3(transform.position.x, 0, 0);
        newKillZone.transform.localScale = new Vector3(1, Random.Range(0.5f, 1f), 1);
        return newKillZone;
    }

    public void DeleteAllKillZones()
    {
        foreach (GameObject zone in KillZones)
        {
            Destroy(zone);
        }

    }

    public void ResetTimer()
    {
        timer = 0;
    }

    void Start()
    {
        timer = timerStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newKillZone = CreateKillZone();
            timer = 0;
            KillZones.Add(newKillZone);
            Destroy(newKillZone, 10);
        }

        timer += Time.deltaTime;

    }
}

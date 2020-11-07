using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneGenerator : MonoBehaviour
{

    [SerializeField] private GameObject KillZone = null;
    private List<GameObject> KillZones = new List<GameObject>();
    public float maxTime = 10;
    [SerializeField] private float height = 10;
    private float timer = 0;
    // Start is called before the first frame update

    GameObject CreateKillZone()
    {
        GameObject newKillZone = Instantiate(KillZone);
        newKillZone.transform.position = new Vector3(transform.position.x, Random.Range(-2.5f, -7.5f), 0);
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

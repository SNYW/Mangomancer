using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeganSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public GameObject[] vegans;

    private float currentCD;

    // Start is called before the first frame update
    void Start()
    {
        currentCD = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    void SpawnTimer()
    {
        currentCD -= Time.deltaTime;
        if(currentCD <= 0)
        {
            currentCD = spawnCooldown;
            SpawnVegan();
        }
    }

    void SpawnVegan()
    {
        var vegan = vegans[Random.Range(0, vegans.Length)];
        Instantiate(vegan, new Vector3(transform.position.x, Random.Range(-2f, 9f), 0), Quaternion.identity);
    }
}

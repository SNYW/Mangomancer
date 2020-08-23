
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public List<MangoSpawnPoint> spawners;
    public static Queue<Rigidbody2D> mangos;
    public static int availSpawners;
    private void Start()
    {
        mangos = new Queue<Rigidbody2D>();
        foreach(Transform t in transform)
        {
            spawners.Add(t.GetComponent<MangoSpawnPoint>());
        }
    }
    private void Update()
    {
        UpdateFreeSpawners();
    }

    public void SpawnMango()
    {
        var index = Random.Range(0, spawners.Count);
        var spawner = spawners[index].GetComponent<MangoSpawnPoint>();
        if (spawner.available)
        {
            spawner.SpawnMango();
        }
        else
        {
            SpawnMango();
        }
    }

    public bool HasFreeSpawner(int numberNeeded)
    {
        return numberNeeded <= availSpawners; 
    }

    public MangoSpawnPoint GetMangoSpawnPoint()
    {
        var spawner = spawners[Random.Range(0, spawners.Count)];
        while (!spawner.available)
        {
            spawner = spawners[Random.Range(0, spawners.Count)];
        }
        return spawner;
    }

    void UpdateFreeSpawners()
    {
        availSpawners = 0;
        foreach (MangoSpawnPoint m in spawners)
        {
            if (m.available)
            {
                availSpawners++;
            }
        }
    }

}

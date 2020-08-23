
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public List<MangoSpawnPoint> spawners;
    public static Queue<Rigidbody2D> mangos;
    private void Start()
    {
        mangos = new Queue<Rigidbody2D>();
        foreach(Transform t in transform)
        {
            spawners.Add(t.GetComponent<MangoSpawnPoint>());
        }
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

    public bool HasFreeSpawner()
    {
        var freeSpawner = false;
        foreach(MangoSpawnPoint m in spawners)
        {
            if (m.available)
            {
                return true;
            }
        }
        return freeSpawner; 
    }

}

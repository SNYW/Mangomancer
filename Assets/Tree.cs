
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public List<MangoSpawnPoint> spawners;

    private void Start()
    {
        foreach(Transform t in transform)
        {
            spawners.Add(t.GetComponent<MangoSpawnPoint>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && HasFreeSpawner())
        {
            SpawnMango();
        }else if (Input.GetKeyDown(KeyCode.E) && !HasFreeSpawner())
        {
            Debug.Log("NO FREE SPAWNERS");
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

    private bool HasFreeSpawner()
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

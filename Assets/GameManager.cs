using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tree.HasFreeSpawner())
        {
            tree.SpawnMango();
        }
        else if (Input.GetKeyDown(KeyCode.E) && !tree.HasFreeSpawner())
        {
            Debug.Log("NO FREE SPAWNERS");
        }
    }
}

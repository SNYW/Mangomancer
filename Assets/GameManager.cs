using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    public Animator Mangomage;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tree.HasFreeSpawner())
        {
            Mangomage.SetTrigger("MakeMango");
            tree.SpawnMango();
        }
        if (Input.GetMouseButtonDown(0))
        {
            ShootMango();
        }
        else if (Input.GetKeyDown(KeyCode.E) && !tree.HasFreeSpawner())
        {
            Debug.Log("NO FREE SPAWNERS");
        }
    }

    private void ShootMango()
    {
        Mangomage.SetTrigger("ShootMango");
        var targetDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mangoToFire = Tree.mangos.Dequeue();
        mangoToFire.AddForce(targetDirection - transform.position, ForceMode2D.Impulse);
    }

}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    public Animator Mangomage;

    public float shootForce;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tree.HasFreeSpawner())
        {
            Mangomage.SetTrigger("MakeMango");
            tree.SpawnMango();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(Tree.mangos.Count > 0)
            {
                ShootMango();
            }
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("HELD");
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
        mangoToFire.GetComponent<MangoDamage>().Activate();
        mangoToFire.AddForce((targetDirection += transform.position)*shootForce, ForceMode2D.Impulse);
    }

}

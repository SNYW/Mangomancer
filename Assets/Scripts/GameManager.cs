using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    public Animator Mangomage;

    public float shootForce;

    public Rigidbody2D mangoToFire;

    private void Update()
    {
        Debug.Log("down and not null: "+(Input.GetMouseButtonDown(0) && mangoToFire != null));
        Debug.Log("down and null: " + (Input.GetMouseButtonDown(0) && mangoToFire == null));
        if (Input.GetKeyDown(KeyCode.E) && tree.HasFreeSpawner())
        {
            Mangomage.SetTrigger("MakeMango");
            tree.SpawnMango();
        }
        if (Input.GetMouseButtonUp(0) && mangoToFire !=null)
        {
                ShootMango();
        }
        else if (Input.GetMouseButton(0) && mangoToFire == null)
        {   mangoToFire = Tree.mangos.Dequeue();
        }
        else if (Input.GetKeyDown(KeyCode.E) && !tree.HasFreeSpawner())
        {
            Debug.Log("NO FREE SPAWNERS");
        }
    }

    private void ShootMango()
    {
        Mangomage.SetTrigger("ShootMango");
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - mangoToFire.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;
        mangoToFire.GetComponent<MangoDamage>().Activate();
        mangoToFire.AddForce(mouseDir * shootForce, ForceMode2D.Impulse);
        mangoToFire = null;
    }
}

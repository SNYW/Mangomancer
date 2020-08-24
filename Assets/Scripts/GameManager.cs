using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    public Animator Mangomage;
    public Mangomage shootMage;
    public float shootForce;
    public Transform mangoHolder;
    public Transform veganHolder;
    public GameObject gameOverPanel;

    public Rigidbody2D mangoToFire;
    private bool playing;

    private void Start()
    {
        playing = true;
    }

    private void Update()
    {
        if (playing)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && tree.HasFreeSpawner(1))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && tree.HasFreeSpawner(2))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && tree.HasFreeSpawner(3))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && tree.HasFreeSpawner(4))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && tree.HasFreeSpawner(5))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(5);
            }
            if (Input.GetMouseButtonDown(0) && mangoToFire != null)
            {
                ShootMango();
            }
            else if (Input.GetMouseButton(0) && mangoToFire == null)
            {
                mangoToFire = Tree.mangos.Dequeue();
            }
        }
    }

    private void ShootMango()
    {
        Mangomage.SetTrigger("ShootMango");
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - mangoToFire.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;
        mangoToFire.GetComponent<MangoDamage>().Activate();
        mangoToFire.AddForce(mouseDir * shootForce, ForceMode2D.Impulse);
        mangoToFire = null;
    }

    public void ResetGame()
    {
        ClearAllTransforms(veganHolder);
        ClearAllTransforms(mangoHolder);
        Tree.mangos.Clear();
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        playing = true;
    }

    private void ClearAllTransforms(Transform holder)
    {
        foreach(Transform t in holder)
        {
            Destroy(t.gameObject);
        }
    }

    public void GameOver()
    {
        playing = false;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

}

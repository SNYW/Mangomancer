using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Tree tree;
    public Animator Mangomage;
    public Mangomage shootMage;
    public float shootForce;
    public Transform mangoHolder;
    public Transform veganHolder;
    public GameObject gameOverPanel;
    public int comboCounter;
    public Text comboCounterText;
    public float mageSpawnCD;
    private float currentMageSpawnCD;

    public Rigidbody2D mangoToFire;
    private bool playing;

    private void Start()
    {
        playing = true;
        comboCounter = 1;
        currentMageSpawnCD = 0;
    }

    private void Update()
    {
        currentMageSpawnCD -= Time.deltaTime;
        if(currentMageSpawnCD <= 0)
        {
            shootMage.StaffSystemOn();
            if (Input.GetKeyDown(KeyCode.E) && tree.HasFreeSpawner(comboCounter))
            {
                Mangomage.SetTrigger("MakeMango");
                shootMage.SpawnSpirit(comboCounter);
                currentMageSpawnCD = mageSpawnCD;
            }
            else if (Input.GetKeyDown(KeyCode.E) && !tree.HasFreeSpawner(comboCounter))
            {
                shootMage.SpawnSpirit(Tree.availSpawners);
                currentMageSpawnCD = mageSpawnCD;
            }
        }
        else
        {
            shootMage.StaffSystemOff();
        }
        if (playing)
        {
            comboCounterText.text = comboCounter.ToString();
            
            
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
        comboCounter = 1;
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

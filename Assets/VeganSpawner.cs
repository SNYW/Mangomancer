using UnityEngine;

public class VeganSpawner : MonoBehaviour
{
    public float spawnCooldown;
    public GameObject[] vegans;

    public bool vertical;

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
            if (vertical)
            {
                SpawnVeganVert();
            }
            else{
                SpawnVeganHorizontal();
            }
        }
    }

    void SpawnVeganVert()
    {
        var vegan = vegans[Random.Range(0, vegans.Length)];
        Instantiate(vegan, new Vector3(transform.position.x, Random.Range(-3f, 18.8f), 0), Quaternion.identity);
    }
    void SpawnVeganHorizontal()
    {
        var vegan = vegans[Random.Range(0, vegans.Length)];
        Instantiate(vegan, new Vector3(Random.Range(2f, 40f), transform.position.y, 0), Quaternion.identity);
    }
}

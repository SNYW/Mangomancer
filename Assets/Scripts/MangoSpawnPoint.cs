
using UnityEngine;

public class MangoSpawnPoint : MonoBehaviour
{
    public GameObject mango;
    public bool available;
    private MangoGrowth mangoGrowth;

    private void Start()
    {
        mangoGrowth = null;
        GetComponent<SpriteRenderer>().enabled = false;
        available = true;
    }

    private void Update()
    {
        if(mangoGrowth != null)
        {
            if (mangoGrowth.grown)
            {
                available = true;
                mangoGrowth = null;
            }
        }
    }

    public void SpawnMango()
    {
       available = false;
       mangoGrowth = Instantiate(mango, transform.position, Quaternion.identity).GetComponent<MangoGrowth>();
    }

}

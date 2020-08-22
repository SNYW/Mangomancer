
using UnityEngine;

public class MangoSpawnPoint : MonoBehaviour
{
    public GameObject mango;

    public void SpawnMango()
    {
       Instantiate(mango, transform.position, Quaternion.identity);
    }

}

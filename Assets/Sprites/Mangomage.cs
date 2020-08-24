using Unity.Mathematics;
using UnityEngine;

public class Mangomage : MonoBehaviour
{
    public Transform spiritSpawn;
    public GameObject mangoSpirit;
    public Tree tree;
    public ParticleSystem staffSystem;
    
    public void SpawnSpirit(int amount)
    {
        
        for(int i = 0; i < amount; i++)
        {
            var spirit = Instantiate(mangoSpirit, spiritSpawn.position.normalized, Quaternion.identity);
            spirit.GetComponent<MangoSpirit>().target = tree.GetMangoSpawnPoint();
        }
    }

    public void StaffSystemOn()
    {
        staffSystem.gameObject.SetActive(true);
    }
    public void StaffSystemOff()
    {
        staffSystem.gameObject.SetActive(false);
    }
}

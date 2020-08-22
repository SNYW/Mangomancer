using UnityEngine;

public class MangoDamage : MonoBehaviour
{
    public float damageFactor;
    public int damage;
    public bool active;

    private void Start()
    {
        var mangoGrowth = GetComponent<MangoGrowth>();
        damage = (int)((mangoGrowth.currentGrownSize* 100) * damageFactor);
    }


    public void Activate()
    {

    }
}

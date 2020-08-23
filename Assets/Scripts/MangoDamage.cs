using UnityEngine;

public class MangoDamage : MonoBehaviour
{
    public float damageFactor;
    public int damage;
    public bool active;
    private ParticleSystem particleSystem;

    private void Start()
    {
        var mangoGrowth = GetComponent<MangoGrowth>();
        damage = (int)((mangoGrowth.currentGrownSize* 100) * damageFactor);
        particleSystem = mangoGrowth.trail;
    }


    public void Activate()
    {
        active = true;
        particleSystem.gameObject.SetActive(true);
        Destroy(this.gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (active)
        {
            if(collision.gameObject.tag == "enemy")
            {
                //Deal Damage
            }
        }
    }
}

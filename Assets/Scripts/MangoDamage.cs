using UnityEngine;

public class MangoDamage : MonoBehaviour
{
    public float damageFactor;
    public bool active;
    private ParticleSystem particleSystem;
    private MangoGrowth mangoGrowth;

    private void Start()
    {
        mangoGrowth = GetComponent<MangoGrowth>();
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
            if (collision.gameObject.tag == "Enemy")
            {
                var vegan = collision.gameObject.GetComponentInParent<Vegan>();
                vegan.Die(mangoGrowth.currentGrownSize * 100);
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}

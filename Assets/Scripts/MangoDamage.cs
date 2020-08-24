using UnityEngine;

public class MangoDamage : MonoBehaviour
{
    public float damageFactor;
    public bool active;
    private ParticleSystem particleSystem;
    private MangoGrowth mangoGrowth;
    private GameManager gameManager;

    private void Start()
    {
        mangoGrowth = GetComponent<MangoGrowth>();
        particleSystem = mangoGrowth.trail;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(active && transform.position.x > 28)
        {
            gameManager.comboCounter = 1;
            Destroy(this.gameObject);
        }
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
                if(gameManager.comboCounter < Tree.availSpawners)
                {
                    gameManager.comboCounter++;
                }
            }
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}

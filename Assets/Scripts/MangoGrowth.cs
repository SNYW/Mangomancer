using UnityEngine;

public class MangoGrowth : MonoBehaviour
{
    public float maxGrownSize;
    public float minGrownSize;
    public float startSize;
    public float currentGrownSize;
    public float maxGrowthSpeed;
    public float minGrowthSpeed;
    public float currentGrowthSpeed;

    public bool grown;

    private Rigidbody2D rb2D;
    public ParticleSystem trail;

    void Start()
    {
        currentGrownSize = Random.Range(minGrownSize, maxGrownSize);
        currentGrowthSpeed = Random.Range(minGrowthSpeed, maxGrowthSpeed);
        grown = false;
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.simulated = false;
        var startScale = new Vector3(0, 0, 1);
        transform.localScale = startScale;
        trail.startSize = currentGrownSize*10;
        trail.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!grown)
        {
            Grow();
        }
    }

    private void Grow()
    {
        if (currentGrownSize > transform.localScale.x)
        {
            var growthAdjustment = currentGrowthSpeed * Time.deltaTime;
            var grownScale = new Vector2(growthAdjustment, growthAdjustment);

            transform.localScale += (Vector3)grownScale;
        }
        else
        {
            var grownScale = new Vector2(currentGrownSize, currentGrownSize);
            Tree.mangos.Enqueue(GetComponent<Rigidbody2D>());
            transform.localScale = (Vector3)grownScale;
            rb2D.simulated = true;
            grown = true;
        }
    }
}

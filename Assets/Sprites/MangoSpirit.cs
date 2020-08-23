using UnityEngine;

public class MangoSpirit : MonoBehaviour
{
    public float speed;

    public MangoSpawnPoint target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(3, 10), Random.Range(3, 10)), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(50, 100));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(target.transform.position, transform.position) < 0.1)
        {
            target.SpawnMango();
            Destroy(this.gameObject);
        }
    }
}

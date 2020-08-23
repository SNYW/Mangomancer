using UnityEngine;

public class Vegan : MonoBehaviour
{
    public GameObject mangomancer;
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        mangomancer = GameObject.Find("Mangomancer");
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mangomancer.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(mangomancer.transform.position, transform.position) < 0.1)
        { 
            // Game Over
        }
    }

    public void Die(float force)
    {
        rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        Destroy(this.gameObject, 2);
    }

}

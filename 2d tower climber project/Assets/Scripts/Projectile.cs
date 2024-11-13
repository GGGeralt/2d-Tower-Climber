using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get => damage; set => damage = value; }
    [SerializeField] float damage;

    public float MaxDistance { get => maxDistance; set => maxDistance = value; }
    [SerializeField] float maxDistance;
    [SerializeField] float passedDistance;
    [SerializeField] LayerMask mask;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().excludeLayers = mask;
    }

    private void FixedUpdate()
    {
        passedDistance += rb.velocity.magnitude * Time.fixedDeltaTime;
        if (passedDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D rigid))
        {
            rigid.AddForce(rb.velocity * damage);
        }
        Destroy(gameObject);
    }

}

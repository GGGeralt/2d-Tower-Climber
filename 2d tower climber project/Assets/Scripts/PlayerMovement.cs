using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    Vector2 movement;
    float horizontal;

    [SerializeField] int jumpForce;

    [SerializeField] bool isGrounded = true;
    [SerializeField] LayerMask groundMask;

    [SerializeField] KeyCode movementKey;
    [SerializeField] MovementSkill movementSkill;

    [SerializeField] KeyCode airKey;
    [SerializeField] AirSkill airSkill;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, rigid2d.velocity.y);

        if (Input.GetKeyDown(movementKey))
        {
            movementSkill.Activate?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(movementKey))
        {
            movementSkill.Deactivate?.Invoke(gameObject);
        }

        if (Input.GetKeyDown(airKey))
        {
            airSkill.Activate?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(airKey))
        {
            airSkill.Deactivate?.Invoke(gameObject);
        }
    }

    //TODO: repair movement to work with MovePosition
    // reapir gravity, that allows also jumping etc
    //change skills to work with new movement
    private void FixedUpdate()
    {
        //rigid2d.AddForce(new Vector2(horizontal * GetComponent<Character>().Speed.Value, rigid2d.velocity.y));
        rigid2d.MovePosition((Vector2)transform.position + new Vector2(horizontal * GetComponent<Character>().Speed.Value * Time.fixedDeltaTime, 0));
    }
}

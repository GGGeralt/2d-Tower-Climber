using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid2d;

    Vector2 movement;
    bool jump;

    [SerializeField] int jumpForce;

    [SerializeField] bool isGrounded = true;
    [SerializeField] LayerMask groundMask;
    float horizontal;

    [SerializeField] KeyCode sprintKey;
    [SerializeField] MovementSkill movementSkill;

    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, rigid2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(sprintKey))
        {
            movementSkill.Activate?.Invoke(gameObject);
            print(movementSkill.name + " activated");
        }

        if (Input.GetKeyUp(sprintKey))
        {
            movementSkill.Deactivate?.Invoke(gameObject);
            print(movementSkill.name + " deactivated");
        }
    }

    private void FixedUpdate()
    {
        //rigid2d.velocity = new Vector2(horizontal * GetComponent<Character>().Speed.Value * 100 * Time.fixedDeltaTime, rigid2d.velocity.y);
        if (jump)
        {
            Jump();
            jump = false;
        }

    }

    public void Jump()
    {
        rigid2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}

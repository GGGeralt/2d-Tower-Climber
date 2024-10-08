using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Character character;

    float horizontal;
    [SerializeField] float lastMovement;

    [SerializeField] bool canMove = true;
    [SerializeField] bool isDashing = false;
    [SerializeField] int dashStrength;

    [SerializeField] bool isGrounded = false;
    [SerializeField] LayerMask groundMask;
    [Space]
    [Header("Keys")]
    [SerializeField] KeyCode movementKey;
    [SerializeField] KeyCode airKey;


    #region UnityFunctions
    private void Awake()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }
    #endregion

    private void GetInput()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, groundMask);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0)
        {
            lastMovement = 1;
        }
        else if (horizontal < 0)
        {
            lastMovement = -1;
        }

        if (Input.GetKeyDown(movementKey))
        {
            character.movementSkill.Activate?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(movementKey))
        {
            character.movementSkill.Deactivate?.Invoke(gameObject);
        }

        if (Input.GetKeyDown(airKey))
        {
            character.airSkill.Activate?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(airKey))
        {
            character.airSkill.Deactivate?.Invoke(gameObject);
        }
    }


    private void Move()
    {
        if (canMove)
        {
            rigid2d.velocity = new Vector2(horizontal * GetComponent<Character>().Speed.Value, rigid2d.velocity.y);
        }
        else if (isDashing)
        {
            rigid2d.velocity = new Vector2(dashStrength * lastMovement, rigid2d.velocity.y);
        }
    }

    public IEnumerator Dash(float dashDuration, int dashStrength)
    {
        isDashing = true;
        canMove = false;

        this.dashStrength = dashStrength;
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        canMove = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * 0.7f);
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}

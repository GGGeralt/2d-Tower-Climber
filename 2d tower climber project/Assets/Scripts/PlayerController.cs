using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    Character character;

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

    float horizontal;
    public float Horizontal { get => horizontal; }


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

        if (Horizontal > 0)
        {
            lastMovement = 1;
        }
        else if (Horizontal < 0)
        {
            lastMovement = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            character.GetAttackSkill().Activate?.Invoke(gameObject);
        }
        if (Input.GetMouseButton(0))
        {
            character.GetAttackSkill().HoldActive?.Invoke(gameObject);
        }
        if (Input.GetMouseButtonUp(0))
        {
            character.GetAttackSkill().Deactivate?.Invoke(gameObject);
        }

        if (Input.GetKeyDown(movementKey))
        {
            character.GetMovementSkill().Activate?.Invoke(gameObject);
        }
        if (Input.GetKey(movementKey))
        {
            character.GetMovementSkill().HoldActive?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(movementKey))
        {
            character.GetMovementSkill().Deactivate?.Invoke(gameObject);
        }

        if (Input.GetKeyDown(airKey))
        {
            character.GetAirSkill().Activate?.Invoke(gameObject);
        }
        if (Input.GetKey(airKey))
        {
            character.GetAirSkill().HoldActive?.Invoke(gameObject);
        }
        if (Input.GetKeyUp(airKey))
        {
            character.GetAirSkill().Deactivate?.Invoke(gameObject);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            character.GetMana().Increase(20);
        }
    }

    private void Move()
    {
        if (canMove)
        {
            rigid2d.velocity = new Vector2(Horizontal * character.GetSpeed().Value, rigid2d.velocity.y);
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
        Character.Instance.GetStamina().isRegenerating = false;

        this.dashStrength = dashStrength;
        yield return new WaitForSeconds(dashDuration);

        Character.Instance.GetStamina().isRegenerating = true;
        isDashing = false;
        canMove = true;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}

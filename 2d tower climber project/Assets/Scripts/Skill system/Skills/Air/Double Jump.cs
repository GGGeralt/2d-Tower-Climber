using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Air/Double Jump")]
public class DoubleJump : AirSkill
{
    [SerializeField] int jumpForce;
    [SerializeField] int maxJumpAmount = 2;
    [SerializeField] private int actualJumpAmount = 0;
    protected override void ActivateSkill(GameObject caster)
    {
        if (caster.GetComponent<PlayerMovement>().GetIsGrounded() && actualJumpAmount >= 1)
        {
            actualJumpAmount = 0;
            Debug.Log("RESET JUMP");
        }
        if (actualJumpAmount < maxJumpAmount)
        {
            Rigidbody2D r2d = caster.GetComponent<Rigidbody2D>();
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
            actualJumpAmount++;
            Debug.Log("JUMP");
        }
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

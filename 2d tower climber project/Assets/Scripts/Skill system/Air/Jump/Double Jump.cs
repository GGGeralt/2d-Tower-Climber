using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Air/Jump/Double Jump")]
public class DoubleJump : AirSkill
{
    [SerializeField] int jumpForce;
    [SerializeField] int maxJumpAmount = 2;
    [SerializeField] private int actualJumpAmount = 0;
    protected override void ActivateSkill(GameObject caster)
    {
        if (caster.GetComponent<PlayerController>().GetIsGrounded() && actualJumpAmount >= 1)
        {
            actualJumpAmount = 0;
        }
        if (actualJumpAmount < maxJumpAmount)
        {
            Rigidbody2D r2d = caster.GetComponent<Rigidbody2D>();
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
            actualJumpAmount++;
        }
    }

    protected override void HoldActiveSkill(GameObject caster)
    {
    }
    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

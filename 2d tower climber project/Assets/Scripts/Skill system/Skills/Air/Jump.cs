using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Air/Jump")]
public class Jump : AirSkill
{
    [SerializeField] int jumpForce;
    protected override void ActivateSkill(GameObject caster)
    {
        if (caster.GetComponent<PlayerMovement>().GetIsGrounded())
        {
            Rigidbody2D r2d = caster.GetComponent<Rigidbody2D>();
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
        }
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

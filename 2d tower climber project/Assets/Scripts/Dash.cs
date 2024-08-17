using UnityEngine;

[CreateAssetMenu]
public class Dash : MovementSkill
{
    [SerializeField] int dashPower = 10;
    protected override void ActivateSkill(GameObject caster)
    {
        //DOUBLE JUMP?!?!?!?!?
        //caster.GetComponent<Rigidbody2D>().AddForce(caster.GetComponent<PlayerMovement>().movement.normalized * dashPower, ForceMode2D.Impulse);
        caster.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), 0).normalized * dashPower, ForceMode2D.Impulse);
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

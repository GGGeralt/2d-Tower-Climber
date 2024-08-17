using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Air/Jump")]
public class Jump : AirSkill
{
    [SerializeField] int jumpForce;
    protected override void ActivateSkill(GameObject caster)
    {
        caster.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

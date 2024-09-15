using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Movement/Dash")]
public class Dash : MovementSkill
{
    [SerializeField] int dashStrength;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    protected override void ActivateSkill(GameObject caster)
    {
        PlayerMovement movement = caster.GetComponent<PlayerMovement>();
        movement.StartCoroutine(movement.Dash(dashDuration, dashStrength));
    }

    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

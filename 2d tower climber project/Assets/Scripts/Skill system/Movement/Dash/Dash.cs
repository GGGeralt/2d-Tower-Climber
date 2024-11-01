using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Movement/Dash/Dash")]
public class Dash : MovementSkill
{
    [SerializeField] int dashStrength;
    [SerializeField] float dashDuration;
    [SerializeField] float dashCooldown;
    protected override void ActivateSkill(GameObject caster)
    {
        if (StatCheck())
        {
            PlayerController movement = caster.GetComponent<PlayerController>();
            movement.StartCoroutine(movement.Dash(dashDuration, dashStrength));
        }
    }

    protected override void HoldActiveSkill(GameObject caster)
    {
    }
    protected override void DeactivateSkill(GameObject caster)
    {
    }
}

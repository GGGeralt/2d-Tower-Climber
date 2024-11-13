using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Movement/Sprint/Sprint")]
public class Sprint : MovementSkill
{
    [SerializeField] StatModifier modifier;

    protected override void ActivateSkill(GameObject caster)
    {
        if (StatCheck())
        {
            Character.Instance.GetStamina().isRegenerating = false;
            caster.GetComponent<Character>().GetSpeed().AddModifier(modifier);
        }
    }
    protected override void HoldActiveSkill(GameObject caster)
    {
        if (StatCheck())
        {
            Character.Instance.DecreaseStatValue(cost);
        }
    }

    protected override void DeactivateSkill(GameObject caster)
    {
        Character.Instance.GetStamina().isRegenerating = true;
        caster.GetComponent<Character>().GetSpeed().RemoveModifier(modifier);
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Movement/Sprint")]
public class Sprint : MovementSkill
{
    [SerializeField] StatModifier modifier;

    protected override void ActivateSkill(GameObject caster)
    {
        if (Character.Instance.GetStamina().currentValue > 0)
        {
            caster.GetComponent<Character>().GetSpeed().AddModifier(modifier);
        }
    }
    protected override void HoldActiveSkill(GameObject caster)
    {
        Character.Instance.DecreaseStatValue(cost);

        if (Character.Instance.GetStamina().currentValue == 0)
        {
            caster.GetComponent<Character>().GetSpeed().RemoveModifier(modifier);
        }
    }

    protected override void DeactivateSkill(GameObject caster)
    {
        caster.GetComponent<Character>().GetSpeed().RemoveModifier(modifier);
    }


}

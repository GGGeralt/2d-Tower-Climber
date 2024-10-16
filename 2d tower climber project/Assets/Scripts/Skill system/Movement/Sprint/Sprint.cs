using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Movement/Sprint")]
public class Sprint : MovementSkill
{
    [SerializeField] StatModifier modifier;

    protected override void ActivateSkill(GameObject caster)
    {
        caster.GetComponent<Character>().GetSpeed().AddModifier(modifier);
    }

    protected override void DeactivateSkill(GameObject caster)
    {
        caster.GetComponent<Character>().GetSpeed().RemoveModifier(modifier);
    }
}

using System;
using UnityEngine;

[Serializable]
public class ChargedManaBolt : AttackSkill
{
    [SerializeField] GameObject projectileGO;
    [SerializeField] float damage;
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    [SerializeField] float maxSize;
    protected override void ActivateSkill(GameObject caster)
    {
        if (StatCheck())
        {
            Character.Instance.DecreaseStatValue(cost);
        }
    }
    protected override void HoldActiveSkill(GameObject caster)
    {
        if (StatCheck())
        {

        }
    }

    protected override void DeactivateSkill(GameObject caster)
    {

    }
}

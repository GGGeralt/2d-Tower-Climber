using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class SkillBase : ScriptableObject
{
    public new string name;

    public UnityEvent<GameObject> Activate;
    public UnityEvent<GameObject> HoldActive;
    public UnityEvent<GameObject> Deactivate;

    [SerializeField] protected SkillCost cost;
    [SerializeField] protected float cooldoown;

    protected abstract void ActivateSkill(GameObject caster);
    protected abstract void HoldActiveSkill(GameObject caster);
    protected abstract void DeactivateSkill(GameObject caster);

    protected bool StatCheck()
    {
        bool isGood = false;
        float actualCost = 0;

        if (cost.inTime)
        {
            actualCost = 0;
        }
        else
        {
            actualCost = cost.value;
        }

        switch (cost.stat)
        {
            case StatEnum.Health:
                if (Character.Instance.GetHealth().currentValue > actualCost)
                {
                    isGood = true;
                }
                break;
            case StatEnum.Stamina:
                if (Character.Instance.GetStamina().currentValue > actualCost)
                {
                    isGood = true;
                }
                break;
            case StatEnum.Mana:
                if (Character.Instance.GetMana().currentValue > actualCost)
                {
                    isGood = true;
                }
                break;
        }
        return isGood;
    }

    private void OnEnable()
    {
        Activate.AddListener(ActivateSkill);
        HoldActive.AddListener(HoldActiveSkill);
        Deactivate.AddListener(DeactivateSkill);
    }

    private void OnDisable()
    {
        Activate.RemoveListener(ActivateSkill);
        HoldActive.RemoveListener(HoldActiveSkill);
        Deactivate.RemoveListener(DeactivateSkill);
    }
}

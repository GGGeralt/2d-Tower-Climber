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

    public SkillCost cost;

    protected abstract void ActivateSkill(GameObject caster);
    protected abstract void HoldActiveSkill(GameObject caster);
    protected abstract void DeactivateSkill(GameObject caster);

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

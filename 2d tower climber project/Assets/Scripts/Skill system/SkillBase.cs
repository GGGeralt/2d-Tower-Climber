using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class SkillBase : ScriptableObject
{
    public new string name;

    public UnityEvent<GameObject> Activate;
    public UnityEvent<GameObject> Deactivate;

    protected abstract void ActivateSkill(GameObject caster);
    protected abstract void DeactivateSkill(GameObject caster);

    private void OnEnable()
    {
        Activate.AddListener(ActivateSkill);
        Deactivate.AddListener(DeactivateSkill);
    }

    private void OnDisable()
    {
        Deactivate.RemoveListener(ActivateSkill);
        Deactivate.RemoveListener(DeactivateSkill);
    }
}

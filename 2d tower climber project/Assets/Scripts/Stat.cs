using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] int baseValue;
    [SerializeField] List<StatModifier> modifiers;
    [SerializeField] int finalValue;

    public int Value
    {
        get
        {
            return CalculateFinalValue();
        }
    }

    private int CalculateFinalValue()
    {
        int value = baseValue;
        foreach (StatModifier modifier in modifiers)
        {
            value += modifier.Value;
        }
        finalValue = value;
        return value;
    }

    public void AddModifier(StatModifier modifier)
    {
        modifiers.Add(modifier);
    }
    public bool RemoveModifier(StatModifier modifier)
    {
        return modifiers.Remove(modifier);
    }
}

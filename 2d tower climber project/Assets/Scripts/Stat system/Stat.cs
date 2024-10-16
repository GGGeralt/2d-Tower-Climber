using System;
using System.Collections.Generic;
using UnityEngine;

public enum StatEnum
{
    Health,
    Stamina,
    Mana
}

[Serializable]
public class Stat
{
    [SerializeField] private int finalValue;
    [Space]
    [SerializeField] private int baseValue;
    [SerializeField] private List<StatModifier> modifiers;

    public int Value
    {
        get
        {
            return CalculateFinalValue();
        }
    }

    public Stat()
    {
    }


    public Stat(int value)
    {
        baseValue = value;
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

using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField] int value;

    public StatModifier()
    {
    }
    public StatModifier(int value)
    {
        this.value = value;
    }

    public int Value
    {
        get
        {
            return value;
        }
    }
}

using System;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField] int value;

    public StatModifier()
    {
        this.value = value;
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

using System;
using UnityEngine;

[Serializable]
public class ChangeableStat
{
    [SerializeField] public Stat maxValue;
    [SerializeField] public float currentValue;

    public ChangeableStat()
    {
    }

    public ChangeableStat(int value)
    {
        Debug.Log(value);
        maxValue = new Stat(value);
        currentValue = value;
    }

    public void Increase(float value)
    {
        currentValue = Mathf.Clamp(currentValue + value, 0, maxValue.Value);
    }
    public void Decrease(float value)
    {
        currentValue = Mathf.Clamp(currentValue - value, 0, maxValue.Value);
    }
}

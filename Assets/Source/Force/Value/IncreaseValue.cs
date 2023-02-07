using UnityEngine;

public class IncreaseValue : IForceValue
{
    private float _value;
    private float _increase;

    public IncreaseValue(float value, float increase)
    {
        _value = value;
        _increase = Mathf.Abs(increase);
    }

    public virtual float Value(float t)
    {
        float finalValue = FinalValue(_value, _increase, t);
        return (_value + finalValue) * 0.5f * t;
    }

    protected virtual float FinalValue(float value, float increase, float time)
    {
        return value + increase * time;
    }
}
using UnityEngine;

public class DecreasingValue : IncreaseValue
{
    private float _zeroValueTime;

    public DecreasingValue(float value, float increase)
        : base(value, increase)
    {
        _zeroValueTime = value / increase;
    }

    public sealed override float Value(float t)
    {
        float time = Mathf.Clamp(t, 0, _zeroValueTime);
        return base.Value(time);
    }

    protected sealed override float FinalValue(float value, float increase, float time)
    {
        return base.FinalValue(value, -increase, time);
    }
}
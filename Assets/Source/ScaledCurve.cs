using UnityEngine;
using System;

[Serializable]
public class ScaledCurve
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _maxTime;

    public ScaledCurve(AnimationCurve curve, float maxValue, float maxTime)
    {
        _curve = curve;
        _maxTime = maxTime;
        _maxValue = maxValue;
    }

    public float Evaluate(float time)
    {
        time = Mathf.Clamp(time, 0, _maxTime);
        return _curve.Evaluate(time / _maxTime) * _maxValue;
    }
}
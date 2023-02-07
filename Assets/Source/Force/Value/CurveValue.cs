using UnityEngine;

public class CurveValue : IForceValue
{
    private class ScaledCurve
    {
        private AnimationCurve _curve;
        private float _maxValue;
        private float _maxTime;

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

    private ScaledCurve _curve;

    private int _accuracy;

    private float StepSize(float time, int iterations) => time / iterations;

    public CurveValue(AnimationCurve curve, float maxTime, float maxValue, int accuracy = 16)
    {
        _curve = new ScaledCurve(curve, maxValue, maxTime);
        _accuracy = accuracy;
    }

    private float CalculateArea(ScaledCurve curve, float time, int iterations)
    {
        float stepSize = StepSize(time, iterations);
        float area = 0;

        for (int i = 0; i < iterations; i++)
        {
            float curveValue = curve.Evaluate(stepSize * i);
            area += curveValue * stepSize;
        }

        return area;
    }

    public float Value(float t)
    {
        return CalculateArea(_curve, t, _accuracy);
    }
}
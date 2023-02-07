using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    //[CreateAssetMenu(fileName = "CurveValue", menuName = "Force/Value", order = 0)]
    [Serializable]
    public class CurveValue : ForceValue
    {
        [SerializeField] private ScaledCurve _curve;
        [SerializeField] private int _accuracy;

        private float StepSize(float time, int iterations) => time / iterations;

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

        public override float Value(float t)
        {
            return CalculateArea(_curve, t, _accuracy);
        }
    }
}
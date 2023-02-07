using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    //[CreateAssetMenu(fileName = "IncreaseValue", menuName = "Force/Value", order = 0)]
    [Serializable]
    public class IncreaseValue : ForceValue
    {
        [SerializeField] private float _value;
        [SerializeField] private float _increase;

        protected (float value, float increase) GetFields 
            => (_value, _increase);

        public override float Value(float t)
        {
            float finalValue = FinalValue(_value, _increase, t);
            return (_value + finalValue) * 0.5f * t;
        }

        protected virtual float FinalValue(float value, float increase, float time)
        {
            return value + increase * time;
        }

        private void OnValidate()
        {
            _increase = Mathf.Abs(_increase);
        }
    }
}
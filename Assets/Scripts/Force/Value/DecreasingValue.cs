using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    //[CreateAssetMenu(fileName = "DecreasingValue", menuName = "Force/Value", order = 0)]
    [Serializable]
    public class DecreasingValue : IncreaseValue
    {
        private float _zeroValueTime;

        private void OnEnable()
        {
            var fields = base.GetFields;
            _zeroValueTime = fields.value / fields.increase;
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
}
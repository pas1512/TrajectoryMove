using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    //[CreateAssetMenu(fileName = "ConstantValue", menuName = "Force/Value", order = 0)]
    [Serializable]
    public class ConstantValue : ForceValue
    {
        [SerializeField] private float _value;

        public override float Value(float t) => _value * t;
    }
}
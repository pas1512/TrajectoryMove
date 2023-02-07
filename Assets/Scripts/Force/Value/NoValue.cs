using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    //[CreateAssetMenu(fileName = "NoValue", menuName = "Force/Value", order = 0)]
    [Serializable]
    public class NoValue : ForceValue
    {
        public override float Value(float modifier) => 0;
    }
}
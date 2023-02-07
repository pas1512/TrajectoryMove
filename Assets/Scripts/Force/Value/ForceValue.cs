using System;
using UnityEngine;

namespace TrajectoryProject.ForceValue
{
    [Serializable]
    public abstract class ForceValue : ScriptableObject
    {
        public abstract float Value(float t);
    }
}
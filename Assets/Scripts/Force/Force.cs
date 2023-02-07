using UnityEngine;

namespace TrajectoryProject
{
    public abstract class Force : ScriptableObject
    {
        public abstract Vector3 GetVelocity(float time, PointVelocity velocity);
    }
}
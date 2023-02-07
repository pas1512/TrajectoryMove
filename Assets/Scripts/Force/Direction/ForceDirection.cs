using UnityEngine;

namespace TrajectoryProject.ForceDirection
{
    public abstract class ForceDirection : ScriptableObject
    {
        public abstract Vector3 Direction(PointVelocity currentVelocity);
    }
}
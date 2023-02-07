using UnityEngine;

namespace TrajectoryProject
{
    [CreateAssetMenu(fileName = "NoForce", menuName = "Force/NoForce", order = 0)]
    public class NoForce : Force
    {
        public override Vector3 GetVelocity(float time, PointVelocity velocity)
            => Vector3.zero;
    }
}
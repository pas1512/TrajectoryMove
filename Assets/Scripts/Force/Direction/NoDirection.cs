using UnityEngine;

namespace TrajectoryProject.ForceDirection
{
    [CreateAssetMenu(fileName = "NoDirection", menuName = "Force/Direction/NoDirection", order = 0)]
    public class NoDirection : ForceDirection
    {
        public override Vector3 Direction(PointVelocity velocity) => Vector3.zero;
    }
}
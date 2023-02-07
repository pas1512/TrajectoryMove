using UnityEngine;

namespace TrajectoryProject.ForceDirection
{
    [CreateAssetMenu(fileName = "LocalDirection", menuName = "Force/Direction/LocalDirection", order = 0)]
    public class LocalDirection : StaticDirection
    {
        public override Vector3 Direction(PointVelocity currentVelocity)
        {
            Quaternion localSpace = Quaternion.Euler(currentVelocity.Velocity);
            return (localSpace * base.GetDirection).normalized;
        }
    }
}
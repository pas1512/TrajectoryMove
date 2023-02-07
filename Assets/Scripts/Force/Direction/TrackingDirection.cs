using UnityEngine;

namespace TrajectoryProject.ForceDirection
{
    [CreateAssetMenu(fileName = "TrackingDirection", menuName = "Force/Direction/TrackingDirection", order = 0)]
    public class TrackingDirection : StaticDirection
    {
        private TransformObserver _target;

        public void SetTarget(TransformObserver target)
        {
            _target = target;
        }

        public override Vector3 Direction(PointVelocity currentVelocity)
        {
            if (_target.TargetUnseted)
                return base.GetDirection;

            Vector3 direction = _target.Position - currentVelocity.Point;
            return direction.normalized;
        }
    }
}
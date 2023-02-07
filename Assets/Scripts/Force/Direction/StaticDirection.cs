using UnityEngine;

namespace TrajectoryProject.ForceDirection
{
    [CreateAssetMenu(fileName = "StaticDirection", menuName = "Force/Direction/StaticDirection", order = 0)]
    public class StaticDirection : ForceDirection
    {
        [SerializeField] private Vector3 _direction;
        protected Vector3 GetDirection => _direction;

        public override Vector3 Direction(PointVelocity velocity) => _direction;

        private void OnValidate()
        {
            _direction = _direction.normalized;
        }
    }
}
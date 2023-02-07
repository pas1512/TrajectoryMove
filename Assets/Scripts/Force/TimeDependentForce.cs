using UnityEngine;
using TrajectoryProject.ForceDirection;
using TrajectoryProject.ForceValue;

namespace TrajectoryProject
{
    [CreateAssetMenu(fileName = "TimeDependentForce", menuName = "Force/TimeDependentForce", order = 0)]
    public class TimeDependentForce : Force
    {
        [SerializeField] private ConstantValue _value;
        [SerializeField] private StaticDirection _direction;

        public override Vector3 GetVelocity(float time, PointVelocity velocity)
        {
            return _direction.Direction(velocity) * _value.Value(time);
        }
    }
}
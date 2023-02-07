using UnityEngine;

public class TimeDependentForce : IForce
{
    private IForceValue _value;
    private IForceDirection _direction;

    public TimeDependentForce(IForceValue value, IForceDirection direction)
    {
        _value = value;
        _direction = direction;
    }

    public virtual Vector3 GetVelocity(float time, Vector3 velocity)
    {
        return _direction.Direction(velocity) * _value.Value(time);
    }
}
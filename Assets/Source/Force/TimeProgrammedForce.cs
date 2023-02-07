using UnityEngine;

public class TimeProgrammedForce: TimeDependentForce
{
    private float _activateTime;

    public TimeProgrammedForce(IForceValue value, IForceDirection direction, float activateTime)
        : base(value, direction) 
    {
        _activateTime = activateTime;
    }

    public override Vector3 GetVelocity(float time, Vector3 velocity)
    {
        float offsetedTime = time - _activateTime;
        offsetedTime = offsetedTime < 0 ? 0 : offsetedTime;
        return base.GetVelocity(offsetedTime, velocity);
    }
}
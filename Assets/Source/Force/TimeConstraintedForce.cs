using UnityEngine;

public class TimeConstraintedForce : TimeProgrammedForce
{
    private float _releaseTime;
    public float ReleaseTime => _releaseTime;

    public TimeConstraintedForce(IForceValue value, IForceDirection direction, float activateTime, float activeTime)
        : base(value, direction, activateTime)
    {
        _releaseTime = activateTime + activeTime;
    }

    public override Vector3 GetVelocity(float time, Vector3 velocity)
    {
        float modifiedTime = time > _releaseTime ? _releaseTime : time;
        return base.GetVelocity(modifiedTime, velocity);
    }
}
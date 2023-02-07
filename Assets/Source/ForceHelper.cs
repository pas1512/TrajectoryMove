using UnityEngine;

public static class ForceHelper
{
    public static IForce Gravity => MakeGravityForce();

    public static class ForcesNames
    {
        public static string LAUNCH = "launch";
        public static string INERTIA = "inertia";
        public static string GRAVITY = "gravity";
    }

    public enum DirectionType
    {
        Global,
        Local
    }
    
    public static IForceDirection MakeDirection(Vector3 direction, DirectionType directionType)
    {
        if (directionType == DirectionType.Global)
            return new GlobalDirection(direction);
        else
            return new LocalDirection(direction);
    }

    public static IForce MakeGravityForce()
    {
        Vector3 gravity = Physics.gravity;
        IForceValue valueType = new IncreaseValue(0, gravity.magnitude);
        IForceDirection direction = new GlobalDirection(gravity.normalized);
        return new TimeDependentForce(valueType, direction);
    }

    public static IForce MakeInertialForce(float startValue, Vector3 startDirection, float resistance)
    {
        IForceValue valueType;

        if (resistance != 0)
            valueType = new DecreasingValue(startValue, resistance);
        else
            valueType = new ConstantValue(startValue);

        IForceDirection direction = new GlobalDirection(startDirection);
        return new TimeDependentForce(valueType, direction);
    }

    public static TimeConstraintedForce MakeLaunchForce(AnimationCurve curve, Vector3 velocity, float duration, float maxValue)
    {
        CurveValue launchForceValue =
            new CurveValue(curve, duration, maxValue);

        IForceDirection launchDirecion =
            ForceHelper.MakeDirection(velocity, ForceHelper.DirectionType.Global);

        return new TimeConstraintedForce(launchForceValue, launchDirecion, 0, duration);
    }

    public static IForce MakeInertialForce(float startValue, float startTime, Vector3 startDirection, float resistance)
    {
        DecreasingValue value =
            new DecreasingValue(startValue, resistance);

        GlobalDirection direction = new GlobalDirection(startDirection);

        return new TimeProgrammedForce(value, direction, startTime);
    }

    public static IForce MakeRocketGravityForce(float startTime)
    {
        Vector3 gravity = Physics.gravity;
        IForceValue valueType = new IncreaseValue(0, gravity.magnitude);
        IForceDirection direction = new GlobalDirection(gravity.normalized);
        return new TimeProgrammedForce(valueType, direction, startTime);
    }
}
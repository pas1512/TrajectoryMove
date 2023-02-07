public class ConstantValue : IForceValue
{
    private float _value;

    public ConstantValue(float value)
    {
        _value = value;
    }

    public float Value(float t) => _value * t;
}
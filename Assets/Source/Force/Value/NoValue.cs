public class NoValue : IForceValue
{
    private float _value;

    public NoValue(float value)
    {
        _value = value;
    }

    public float Value(float modifier) => _value;
}
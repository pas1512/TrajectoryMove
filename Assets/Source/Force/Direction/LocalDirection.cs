using UnityEngine;

public class LocalDirection : IForceDirection
{
    private Vector3 _direction;

    public LocalDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public Vector3 Direction(Vector3 velocity)
    {
        Quaternion localSpace = Quaternion.Euler(velocity);
        return (localSpace * _direction);
    }
}
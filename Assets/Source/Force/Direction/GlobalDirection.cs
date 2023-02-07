using UnityEngine;

public class GlobalDirection : IForceDirection
{
    private Vector3 _direction;

    public GlobalDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public Vector3 Direction(Vector3 velocity) => _direction;
}
using UnityEngine;

public class NoDirection : IForceDirection
{
    public Vector3 Direction(Vector3 velocity) => Vector3.zero;
}
using UnityEngine;

public class NoForce : IForce
{
    public Vector3 GetVelocity(float time, Vector3 velocity) => Vector3.zero;
}
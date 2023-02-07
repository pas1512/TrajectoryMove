using UnityEngine;

public interface IForce
{
    public Vector3 GetVelocity(float time, Vector3 velocity);
}
using System.Collections.Generic;
using UnityEngine;

public class Trajectory
{
    private Vector3 _startPosition;
    private Dictionary<string, IForce> _forces;

    public Vector3 StartPosition => _startPosition;

    public Trajectory(Vector3 startPosition)
    {
        _startPosition = startPosition;
        _forces = new Dictionary<string, IForce>();
    }

    public Vector3 GetPoint(float time)
    {
        Vector3 finalPoint = Vector3.zero;
        Vector3 velocity = Vector3.zero;
        foreach (var force in _forces)
        {
            finalPoint += force.Value.GetVelocity(time, velocity);
            velocity = finalPoint - _startPosition;
        }

        return _startPosition + velocity;
    }

    public void ChangeForce(string name, IForce newForce)
    {
        _forces[name] = newForce;
    }

    public void RemoveForce(string name)
    {
        _forces.Remove(name);
    }

    public void AddForce(string name, IForce newForce)
    {
        _forces.Add(name, newForce);
    }
}
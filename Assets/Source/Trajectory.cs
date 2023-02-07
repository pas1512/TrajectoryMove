using System.Collections.Generic;
using TrajectoryProject;
using UnityEngine;

public class Trajectory
{
    private Vector3 _startPosition;
    private Dictionary<string, Force> _forces;

    public Vector3 StartPosition => _startPosition;

    public Trajectory(Vector3 startPosition)
    {
        _startPosition = startPosition;
        _forces = new Dictionary<string, Force>();
    }

    public Vector3 GetPoint(float time)
    {
        Vector3 finalPoint = Vector3.zero;
        Vector3 velocity = Vector3.zero;
        foreach (var force in _forces)
        {
            finalPoint += force.Value.GetVelocity(time, new PointVelocity(Vector3.zero, Vector3.zero));
            velocity = finalPoint - _startPosition;
        }

        return _startPosition + velocity;
    }

    public void ChangeForce(string name, Force newForce)
    {
        _forces[name] = newForce;
    }

    public void RemoveForce(string name)
    {
        _forces.Remove(name);
    }

    public void AddForce(string name, Force newForce)
    {
        _forces.Add(name, newForce);
    }
}
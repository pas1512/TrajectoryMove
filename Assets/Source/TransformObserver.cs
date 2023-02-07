using UnityEngine;

public struct TransformObserver
{
    private Transform _target;

    public Vector3 Position => _target.position;
    public Quaternion Rotation => _target.rotation;
    public bool TargetSeted => _target != null;
    public bool TargetUnseted => _target == null;

    public TransformObserver(Transform target)
    {
        _target = target;
    }
}
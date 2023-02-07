using System.Linq;
using UnityEngine;

public class TrajectoryMover : MonoBehaviour
{
    private Trajectory _trajectory;
    private Transform _transform;
    private Timer _sinceStart;

    private Vector3 _oldPoint;
    private float _speed;
    private bool _started = false;

    public float Speed => _speed;
    public Vector3 Direction => _transform.forward;

    public void StartMove(Trajectory trajectory)
    {
        if(!_started)
        {
            _sinceStart = new Timer();
            _transform = GetComponent<Transform>();
            _trajectory = trajectory;
            _oldPoint = trajectory.StartPosition;
            _speed = 0;
            _started = true;
            _sinceStart.Set();
        }
    }

    private void Update()
    {
        if(_started)
        {
            Vector3 point = _transform.position + _trajectory.GetPoint(_sinceStart.Current());
            Vector3 velocity = point - _oldPoint;
            
            if (Hited(_oldPoint, velocity))
            {
                _started = false;
            }

            _speed = velocity.magnitude;
            _oldPoint = point;
            _transform.LookAt(point);
            _transform.position = point;
        }
    }

    private bool Hited(Vector3 point, Vector3 velocity)
    {
        Ray ray = new Ray(point, velocity);
        RaycastHit[] hits = Physics.RaycastAll(point, velocity.normalized, velocity.magnitude);
        return hits.Any(h => h.collider is TerrainCollider);
    }
}

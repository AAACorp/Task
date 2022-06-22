using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _distanceTreshold = .1f;

    private Transform _currentWaypoint;
    private NavMeshAgent _agent;

    private bool _canMove = false;

    public void SetAbilityToMove()
    {
        _canMove = true;
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _currentWaypoint = _waypoints.GetNextWaypoint(_currentWaypoint);
        transform.position = _currentWaypoint.position;

        _currentWaypoint = _waypoints.GetNextWaypoint(_currentWaypoint);
    }

    void Update()
    {
        if (_canMove)
        {
            _canMove = false;
            _agent.SetDestination(_currentWaypoint.position);
        }

        if (Vector3.Distance(transform.position, _currentWaypoint.position) < _distanceTreshold)
        {
            _currentWaypoint = _waypoints.GetNextWaypoint(_currentWaypoint);
        }

        transform.DOLookAt(new Vector3(_currentWaypoint.GetChild(0).position.x, transform.position.y,_currentWaypoint.GetChild(0).position.z), 1f);
    }
}

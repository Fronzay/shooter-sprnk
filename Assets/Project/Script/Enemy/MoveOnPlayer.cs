using UnityEngine;
using UnityEngine.AI;

public class MoveOnPlayer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private Transform _transform;

    [SerializeField] private float _distance;

    private void Update()
    {
        _agent.SetDestination(PlayerStats.Instance.playerPosition.position);
    }

    private bool IsMoving()
    {
        return Vector3.Distance(_transform.position, _transform.position) >= _distance;
    }

}

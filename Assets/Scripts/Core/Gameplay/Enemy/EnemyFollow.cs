using Core.Gameplay.State;
using UnityEngine;

namespace Core.Gameplay.Enemy
{
    public class EnemyFollow : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _startFollowDistance;
        [SerializeField] private float _endFollowDistance;
        [SerializeField] private LayerMask _targetLayer;

        private Transform _target;
        private bool _isStopped;
        private GameStateController _stateController;

        private readonly Collider2D[] _targetResults = new Collider2D[MAX_TARGETS];

        private const int MAX_TARGETS = 6;

        private void Awake()
        {
            _stateController = FindObjectOfType<GameStateController>();
        }

        private void OnEnable()
        {
            _stateController.OnFinished += StopFollow;
            _stateController.OnGameOver += StopFollow;
        }

        private void OnDisable()
        {
            _stateController.OnFinished -= StopFollow;
            _stateController.OnGameOver -= StopFollow;
        }

        private void StopFollow()
        {
            _isStopped = true;
        }

        private void Update()
        {
            if (_isStopped)
                return;

            SearchForTarget();
            Follow();
        }

        private void Follow()
        {
            if (_target == null)
                return;

            transform.position = Vector2.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        }

        private void SearchForTarget()
        {
            _target = null;
            int targetsInRange = Physics2D.OverlapCircleNonAlloc(transform.position, _startFollowDistance, _targetResults, _targetLayer);
            if(targetsInRange > 0)
            {
                HandleTargets(targetsInRange);
            }
        }

        private void HandleTargets(int targetsInRange)
        {
            _target = GetNearestTarget(targetsInRange);
        }

        private Transform GetNearestTarget(int targetsInRange)
        {
            Transform nearestTarget = _targetResults[0].transform;
            for (int i = 1; i < targetsInRange; i++)
            {
                if (_targetResults[i] == null)
                    continue;

                if (Vector2.Distance(nearestTarget.position, transform.position) > Vector2.Distance(_targetResults[i].transform.position, transform.position))
                    nearestTarget = _targetResults[i].transform;
            }

            return nearestTarget;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _startFollowDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _endFollowDistance);
        }
    }
}
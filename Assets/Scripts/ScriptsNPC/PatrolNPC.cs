using UnityEngine;
using System.Collections;

public class PatrolNPC : MonoBehaviour
{
    public Vector2[] patrolPoints;
    public float speed;
    public float pauseDuration;
    
    private bool _isPaused;
    public Vector2 _patrolDirection;
    private int _currentPatrolIndex;
    private Rigidbody2D _body;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _patrolDirection =  patrolPoints[_currentPatrolIndex];
        StartCoroutine(SetPatrolPoint());
    }

    void Update()
    {
        if (_isPaused)
        {
            _body.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 direction = (_patrolDirection - (Vector2)transform.position).normalized;
        _body.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, _patrolDirection) < .1f)
        {
            StartCoroutine(SetPatrolPoint());
        }
    }

    IEnumerator SetPatrolPoint()
    {
        _isPaused = true;
        
        yield return new WaitForSeconds(pauseDuration);
        
        _currentPatrolIndex = (_currentPatrolIndex + 1) % patrolPoints.Length;
        _patrolDirection =  patrolPoints[_currentPatrolIndex];
        _isPaused = false;
    }
}

using System.Collections;
using UnityEngine;

public class WanderNPC : MonoBehaviour
{
    [Header("Wander Area")] public float wanderWidth;
    public float wanderHeight;
    public Vector2 startingPosition;
    public float moveSpeed;
    public float pauseDuration;

    private Rigidbody2D _body;
    private Vector2 _wanderDirection;
    private bool _isPaused;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _wanderDirection = GetRandomTarget();
    }

    private void Update()
    {
        if (_isPaused)
        {
            _body.linearVelocity = Vector2.zero;
            return;
        }
        
        if(Vector2.Distance(transform.position, _wanderDirection) < .1)
        {
            StartCoroutine(PauseAndPickNew());
        }
        Vector2 direction = (_wanderDirection - (Vector2)transform.position).normalized;
        _body.linearVelocity = direction * moveSpeed;
    }

    IEnumerator  PauseAndPickNew()
    {
        _isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        
        _wanderDirection = GetRandomTarget();
        _isPaused = false;
    }

    private Vector2 GetRandomTarget()
    {
        float halfWidth = wanderWidth / 2;
        float halfHeight = wanderHeight / 2;
        int edge = Random.Range(0, 4);

        return edge switch
        {
            0 => new Vector2(startingPosition.x - halfWidth,
                Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)), //left
            
            1 => new Vector2(startingPosition.x + halfWidth,
                Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)), //right
            
            2 => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y - halfHeight), //bottom
            
            _ => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y + halfHeight), //up
        };
    }

private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startingPosition, new Vector3(wanderWidth, wanderHeight, 0));
    }
}

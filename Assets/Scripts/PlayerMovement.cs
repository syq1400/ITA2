using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _body;
    
    public float moveSpeed;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        //Debug.Log("awake working movement");
    }

    private void OnMovement(InputValue value)
    {
        _movement = value.Get<Vector2>();
        //Debug.Log("moving working movement");
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + _movement * StatsManager.Instance.moveSpeed * Time.fixedDeltaTime);
    }
}

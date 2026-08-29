using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private PlayerInputMovement _playerControls;
    private Vector2 _movement;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _playerControls = new PlayerInputMovement();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Update()
    {
        PlayerInputMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void PlayerInputMovement()
    {
        _movement = _playerControls.Movement.WASDMove.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * moveSpeed  * Time.fixedDeltaTime);
    }
}

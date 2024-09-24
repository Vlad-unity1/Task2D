using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        CheckGrounded();
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Move(Vector3 direction)
    {
        _rb.velocity = new Vector2(direction.x * _moveSpeed, _rb.velocity.y);
        FlipSprite(direction.x);
    }

    private void CheckGrounded()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }

    private void FlipSprite(float direction)
    {
        if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}

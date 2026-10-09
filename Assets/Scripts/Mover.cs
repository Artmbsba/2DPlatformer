using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask _platformMask;

    private Rigidbody2D _rigidbody;
    private float _rayDistance = 0.5f;
    private int _maxJump = 2;
    private int _jumpUsed;

    public bool CanJump => _jumpUsed < _maxJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 1f;
        _rigidbody.freezeRotation = true;
        _rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    public float Move(Vector2 moveInput)
    {
        float direction = moveInput.x;

        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);

        if (direction != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction);
            transform.localScale = scale;
        }

        return Mathf.Abs(direction) * _moveSpeed;
    }

    public void Jump()
    {
        if (CanJump || IsGround())
        {
            _jumpUsed++;

            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
        }
    }

    private bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody.position, Vector2.down, _rayDistance, _platformMask);

        if (hit.collider != null)
        {
            _jumpUsed = 0;

            return true;
        }
        else
        {
            return false;
        }
    }
}
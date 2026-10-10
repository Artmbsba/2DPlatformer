using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;     

    public float Move(Vector2 moveInput, Rigidbody2D rigidbody)
    {
        float direction = moveInput.x;

        rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, rigidbody.linearVelocity.y);

        if (direction != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(direction);
            transform.localScale = scale;
        }

        return Mathf.Abs(direction) * _moveSpeed;
    }
}

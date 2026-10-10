using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _platformMask;

    private float _rayDistance = 0.5f;

    public bool IsGround(Rigidbody2D rigidbody)
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, Vector2.down, _rayDistance, _platformMask);

        if (hit.collider != null)
            return true;
        else
            return false;
    }
}
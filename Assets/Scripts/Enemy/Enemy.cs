using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PatrolRoute))]
[RequireComponent(typeof(MoverEnemy))]
[RequireComponent(typeof(Animation))]
public class Enemy : MonoBehaviour
{
    private Animation _animation;
    private PatrolRoute _patrolRoute;
    private MoverEnemy _moverEnemy;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _patrolRoute = GetComponent<PatrolRoute>();
        _moverEnemy = GetComponent<MoverEnemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 target = _patrolRoute.CurrentTarget;
        Vector2 current = transform.position;

        float direction = target.x - current.x;

        _spriteRenderer.flipX = direction < 0f;

        if (_moverEnemy.MoveTo(target))
            _patrolRoute.MoveToNext();

        _animation.SetSpeed(_moverEnemy.Speed);
    }

    public void SetPatrolZone(PatrolZone patrolZone)
    {
        _patrolRoute.SetPatorlZone(patrolZone);
    }
}

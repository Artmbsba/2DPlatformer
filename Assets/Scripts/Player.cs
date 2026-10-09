using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animation))]
public class Player : MonoBehaviour
{
    private Mover _mover;
    private InputReader _inputReader;
    private Animation _playerAnimation;
    private float _speed;
    private int _coinCount = 0;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _playerAnimation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        _inputReader.MoveInputChanged += OnMove;
        _inputReader.ClickedJump += OnJump;
    }

    private void OnDisable()
    {
        _inputReader.MoveInputChanged -= OnMove;
        _inputReader.ClickedJump -= OnJump;
    }

    private void FixedUpdate()
    {
        _playerAnimation.SetSpeed(_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            OnCoinColdected();

            coin.DestroyCoin();
        }
    }

    private void OnCoinColdected()
    {
        _coinCount++;

        Debug.Log("Вы подобрали монетку");
        Debug.Log($"Баланс: {_coinCount}");
    }

    private void OnMove(Vector2 input)
    {
        _speed = _mover.Move(input);
    }

    private void OnJump()
    {
        _mover.Jump();
    }
}

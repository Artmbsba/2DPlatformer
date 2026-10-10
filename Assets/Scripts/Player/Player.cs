using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(CoinWallet))]
[RequireComponent(typeof(CoinDetector))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private InputReader _inputReader;
    private Animation _playerAnimation;
    private CoinWallet _coinWallet;
    private CoinDetector _coinDetector;
    private GroundDetector _groundDetector;
    private Jumper _jumper;
    private Mover _mover;

    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 1f;
        _rigidbody.freezeRotation = true;
        _rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;

        _inputReader = GetComponent<InputReader>();
        _playerAnimation = GetComponent<Animation>();
        _coinWallet = GetComponent<CoinWallet>();
        _coinDetector = GetComponent<CoinDetector>();
        _groundDetector = GetComponent<GroundDetector>();
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _inputReader.MoveInputChanged += OnMove;
        _inputReader.ClickedJump += OnJump;
        _coinDetector.CoinDetected += OnCoinDetected;
    }

    private void OnDisable()
    {
        _inputReader.MoveInputChanged -= OnMove;
        _inputReader.ClickedJump -= OnJump;
        _coinDetector.CoinDetected -= OnCoinDetected;
    }

    private void FixedUpdate()
    {
        _playerAnimation.SetSpeed(_speed);
    }

    private void OnMove(Vector2 input)
    {
        _speed = _mover.Move(input, _rigidbody);
    }

    private void OnJump()
    {
        if (_groundDetector.IsGround(_rigidbody))
            _jumper.ResetJumps();

        _jumper.Jump(_rigidbody);
    }

    private void OnCoinDetected(Coin coin)
    {
        _coinWallet.AddCoin(coin);
    }
}

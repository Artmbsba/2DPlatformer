using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    public event Action<Vector2> MoveInputChanged;
    public event Action ClickedJump;

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis(Horizontal), 0f);

        MoveInputChanged?.Invoke(input);

        if (Input.GetKeyDown(_jumpKey))
            ClickedJump?.Invoke();
    }
}
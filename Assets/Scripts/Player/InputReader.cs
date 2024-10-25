using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private float _horizontalAxis = 0;
    private float _verticalAxis = 0;
    private float _horizontalMouseAxis = 0;
    private float _verticalMouseAxis = 0;

    public float HorizontalAxis => _horizontalAxis;
    public float VerticalAxis => _verticalAxis;
    public float HorizontalMouseAxis => _horizontalMouseAxis;
    public float VerticalMouseAxis => _verticalMouseAxis;

    private void Update()
    {
        _horizontalAxis = Input.GetAxis(Horizontal);
        _verticalAxis = Input.GetAxis(Vertical);

        _horizontalMouseAxis = Input.GetAxis(MouseX);
        _verticalMouseAxis = Input.GetAxis(MouseY);
    }

    public bool GetInputJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private float baseSpeed;

    private Rigidbody2D _rb;
    private SurfaceEffector2D _surfaceEffector2D;

    private bool _canMove = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;

        PlayerMovement();
    }

    public void DisableControls()
    {
        _canMove = false;
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddTorque(-torqueAmount);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _surfaceEffector2D.speed = slowSpeed;
        }
        else
        {
            _surfaceEffector2D.speed = baseSpeed;
        }
    }
}
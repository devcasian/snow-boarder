using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float slowSpeed;

    [SerializeField] private float baseSpeed;
    // private const float ConstSpeed = 2f;

    private Rigidbody2D _rb;
    private SurfaceEffector2D _surfaceEffector2D;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        RotatePlayer();
        AddBoostAndSlow();
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddTorque(-torqueAmount);
        }
    }

    private void AddBoostAndSlow()
    {
        if (Input.GetKey(KeyCode.UpArrow))
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
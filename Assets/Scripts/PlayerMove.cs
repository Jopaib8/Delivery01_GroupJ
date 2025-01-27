using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;
    
    Rigidbody2D _rigidbody;
    private float _horizontalDir; // Horizontal move direction value [-1, 1]
    public Animator _animator;
    private bool FacingRight = true;
    private bool isDead = false;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }        

    void FixedUpdate()
    {
        if (!isDead)
        {
            Vector2 velocity = _rigidbody.linearVelocity;
            velocity.x = _horizontalDir * Speed;
            _rigidbody.linearVelocity = velocity;

            if (_horizontalDir > 0 && !FacingRight)
            {
                Flip();
            }
            else if (_horizontalDir < 0 && FacingRight)
            {
                Flip();
            }
        }
    }

    // NOTE: InputSystem: "move" action becomes "OnMove" method
    void OnMove(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;

        _animator.SetFloat("Speed", _horizontalDir);
    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void BlockOnDie()
    {
        isDead = true;
    }
}

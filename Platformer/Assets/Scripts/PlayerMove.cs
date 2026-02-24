using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _speed;
    public float _jumpForce;

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float _directionX;
    private float _directionY;
    private bool _isGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _isGround = true;
    }

    void Update()
    {
        _animator.SetFloat("Speed", Math.Abs(_rb.linearVelocityX));
        _animator.SetBool("Jump", !_isGround);

        _directionX = Input.GetAxis("Horizontal");
        _directionY = Input.GetAxis("Vertical");

        _rb.linearVelocity = new Vector2(_directionX * _speed, _rb.linearVelocityY);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _isGround=false;
        }

        //_rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + 
        //   new Vector2(_directionX, 0) * _speed * Time.deltaTime);

        if (_directionX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_directionX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

    private void FixedUpdate()
    {
        
    }
}

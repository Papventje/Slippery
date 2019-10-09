using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool _isGrounded;

    [SerializeField]
    private LayerMask _groundLayers;

    private Vector3 _previousLocation;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), _groundLayers);

        //Handle player input
        if(Input.GetKey(KeyCode.D))
        {
            //Debug.Log(gameObject.name + " is moving right");

            _rb.AddForce(Vector2.right * _speed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            //Debug.Log(gameObject.name + " is moving left");

            _rb.AddForce(Vector2.left * _speed);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x,0);
                _rb.AddForce(new Vector2(0f, jumpForce));
            }
        }

        //Debug.Log(_rb.velocity.magnitude);

        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed);
    }
}

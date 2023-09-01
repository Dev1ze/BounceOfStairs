using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speedForce;
    [SerializeField] private bool isGround;

    private Rigidbody _rigidbody;
    void Start()
    {
        transform.position = _startPosition;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jumping();
        Moving();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
            _rigidbody.drag = 4;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            isGround = false;
            _rigidbody.drag = 0;
        }

    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //Input.TouchCount > 0 = GetKeyDown(KeyCode.Space)
        {
            _rigidbody.velocity = new Vector3(0, _jumpForce, 0);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
        }
    }
    void Moving()
    {
        if (Input.GetKeyDown(KeyCode.A) && isGround)
        {

            _rigidbody.velocity = new Vector3(-_jumpForce, 0, 0);
            _rigidbody.AddForce(Vector3.left * _jumpForce , ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D) && isGround)
        {
            _rigidbody.drag = 4;
            _rigidbody.velocity = new Vector3(_jumpForce, 0, 0);
            _rigidbody.AddForce(Vector3.right * _jumpForce, ForceMode.Impulse);
        }
    }

}

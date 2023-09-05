using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speedForce;
    [SerializeField] private bool isGround;
    private int _countSwipe;

    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    ForwardJump();
        //    RightOrLeftJump();
        //}

        ForwardJump();
        RightOrLeftJump();
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground") isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
    }

    void ForwardJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            _rigidbody.velocity = new Vector3(0, _jumpForce, 0);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
        }

        //Touch touch = Input.GetTouch(0);
        //Vector3 delta = Input.GetTouch(0).deltaPosition;
        //if (touch.phase == TouchPhase.Ended && delta.x == 0 && isGround)
        //{
        //    _rigidbody.velocity = new Vector3(0, _jumpForce, 0);
        //    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
        //}
    }
    void RightOrLeftJump()
    {
        if (Input.GetKeyDown(KeyCode.A) && isGround && _countSwipe < 3)
        {
            _countSwipe++;
            _rigidbody.velocity = new Vector3(-5, 0, 0);
            _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.left * 3, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D) && isGround && _countSwipe > -3)
        {
            _countSwipe--;
            _rigidbody.velocity = new Vector3(5, 0, 0);
            _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.right * 3, ForceMode.Impulse);
        }

        //Touch touch = Input.GetTouch(0);
        //Vector3 delta = Input.GetTouch(0).deltaPosition;
        //if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        //{
        //    if (delta.x < 0 && touch.phase == TouchPhase.Moved && isGround && _countSwipe < 2)
        //    {
        //        _countSwipe++;
        //        _rigidbody.velocity = new Vector3(-_jumpForce, 0, 0);
        //        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //        _rigidbody.AddForce(Vector3.left * _jumpForce, ForceMode.Impulse);
        //    }
        //    if (delta.x > 0 && touch.phase == TouchPhase.Moved && isGround && _countSwipe > -2)
        //    {
        //        _countSwipe--;
        //        _rigidbody.velocity = new Vector3(_jumpForce, 0, 0);
        //        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //        _rigidbody.AddForce(Vector3.right * _jumpForce, ForceMode.Impulse);
        //    }
        //}
    }
}

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
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground") isGround = true;

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) //Input.TouchCount > 0 = GetKeyDown(KeyCode.Space)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
        }
    }

}

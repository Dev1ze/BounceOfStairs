using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    private float _jumpForce = 7f;
    private float _speedForce = 232.8648f; //280
    [SerializeField] private bool isGround;
    public Transform PlayerTarget;
    Score scoreText;

    Vector3 startTouchPosition;
    Vector3 endTouchPosition;


    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        scoreText = FindObjectOfType<Score>();
    }

    void Update()
    {
        ForwardJump();
        RightOrLeftJump();
        PlayerTarget.transform.position = new Vector3(0, transform.position.y,transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = true;
    }

    void ForwardJump()
    {
        //if (Input.GetKey(KeyCode.Space) && isGround)
        //{
        //    _rigidbody.velocity = new Vector3(0, _jumpForce, 0);
        //    _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
        //    isGround = false;
        //    scoreText.IncrementScore();

        //}


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && isGround)
        {
            _rigidbody.velocity = new Vector3(0, _jumpForce, 0);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * _speedForce, ForceMode.Force);
            isGround = false;
            scoreText.IncrementScore();
        }
    }
    void RightOrLeftJump()
    {
        //if (Input.GetKeyDown(KeyCode.A) && isGround)
        //{
        //    _rigidbody.velocity = new Vector3(-5, 0, 0);
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.left * 3, ForceMode.Impulse);
        //}
        //if (Input.GetKeyDown(KeyCode.D) && isGround)
        //{
        //    _rigidbody.velocity = new Vector3(5, 0, 0);
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.right * 3, ForceMode.Impulse);
        //}

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGround)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isGround)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.x > startTouchPosition.x && isGround)
            {
                _rigidbody.velocity = new Vector3(5, 0, 0);
                _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                _rigidbody.AddForce(Vector3.right * 3, ForceMode.Impulse);
            }
            if (endTouchPosition.x < startTouchPosition.x)
            {
                _rigidbody.velocity = new Vector3(-5, 0, 0);
                _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
                _rigidbody.AddForce(Vector3.left * 3, ForceMode.Impulse);
            }
        }
    }
}

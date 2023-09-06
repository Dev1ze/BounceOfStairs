using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool isGround;
    private Rigidbody _rigidbody;
    float _forceUp = 500f;
    float _forceForward = 20f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGround)
        {
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * _forceUp, ForceMode.Impulse);
            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * -_forceForward, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
    }
}

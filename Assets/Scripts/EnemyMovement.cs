using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speedForce;
    void Start()
    {

    }

    void Update()
    {
        transform.position = transform.position - Vector3.forward * _speedForce * Time.deltaTime;
    }
}

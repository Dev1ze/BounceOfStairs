using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool isGround;
    float progress;
    float targetRotation;
    private Rigidbody _rigidbody;
    int countTouchs = 0;
    Vector3 P0, P1, P2, P3 = new Vector3();

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (countTouchs == 1)
        {
            _rigidbody.useGravity = false;
            StartCoroutine(Movement());
        }
        Debug.Log(countTouchs);
    }

    public IEnumerator Movement()
    {
        while (true)
        {
            progress = 0f;
            if (countTouchs < 2) countTouchs++;
            P0 = transform.position;
            P1 = new Vector3(transform.position.x, transform.position.y + 1.729f, transform.position.z - 0.116f);
            P2 = new Vector3(transform.position.x, transform.position.y + 1.729f, transform.position.z - 0.6f);
            P3 = new Vector3(transform.position.x, transform.position.y - 0.875f, transform.position.z - 1.067f);

            while (progress < 1)
            {
                progress += Time.deltaTime;

                targetRotation = Mathf.Lerp(180f, 0f, progress);
                transform.rotation = Quaternion.Euler(targetRotation, 0, 0);

                transform.position = Bezier.StartMoving(P0, P1, P2, P3, progress);
                yield return null;
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") countTouchs++;
    }
}

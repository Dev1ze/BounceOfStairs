using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool isGround;
    float progress;
    public GameObject Player;
    float targetRotation;
    private Rigidbody _rigidbody;
    int countTouchs = 0;
    Vector3 P0, P1, P2, P3 = new Vector3();

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        RemoveEnemy();
        if (countTouchs == 1)
        {
            _rigidbody.useGravity = false;
            StartCoroutine(Movement());
        }
    }

    private void RemoveEnemy()
    {
        if(transform.position.z < (Player.transform.position.z - 4.5f))
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator Movement()
    {
        while (true)
        {
            float speed = 0;
            progress = 0f;
            if (countTouchs < 2) countTouchs++;

            IMoveEnemy moveEnemy = GetComponent<IMoveEnemy>();
            moveEnemy.GetMovementPoint(ref P0, ref P1, ref P2, ref P3, ref speed);

            while (progress < 1)
            {
                progress += Time.deltaTime * speed;

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

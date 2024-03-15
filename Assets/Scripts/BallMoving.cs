using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    [SerializeField] private bool isGround;
    public Transform PlayerTarget;
    public Transform Player;
    Score scoreText;
    public float jumpHeight = 0.875f;
    public float stepLength = 1.0725f;
    [SerializeField] public bool startMoving = false;
    private Rigidbody _rigidbody;
    float progress;
    private List<IMove> movementQueue = new List<IMove>();
    private bool isJumping = false;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        scoreText = FindObjectOfType<Score>();
        InputManager.OnPlayerMovement += CreateQueueMovement;
    }

    private void OnDestroy()
    {
        InputManager.OnPlayerMovement -= CreateQueueMovement;
    }

    void Update()
    {
        //scoreText.IncrementScore();
        PlayerTarget.transform.position = new Vector3(0, transform.position.y,transform.position.z);
    }

    void CreateQueueMovement(IMove somethingMove)
    {
        movementQueue.Add(somethingMove);
        if (!isJumping && isGround)
        {
            isJumping = true;
            _rigidbody.useGravity = false;
            StartCoroutine(Movement());
        }
    }

    public IEnumerator Movement()
    {
        while(movementQueue.Count > 0)
        {
            progress = 0;
            Vector3 P0 = new Vector3();
            Vector3 P1 = new Vector3();
            Vector3 P2 = new Vector3();
            Vector3 P3 = new Vector3(); //4 точки для кривой Бизье

            movementQueue[0].GetMovementPoints(Player, ref P0, ref P1, ref P2, ref P3);

            while (progress <= 1)
            {
                progress += Time.deltaTime * 6f;
                Vector3 P01 = Vector3.Lerp(P0, P1, progress);
                Vector3 P12 = Vector3.Lerp(P1, P2, progress);
                Vector3 P23 = Vector3.Lerp(P2, P3, progress);

                Vector3 P012 = Vector3.Lerp(P01, P12, progress);
                Vector3 P123 = Vector3.Lerp(P12, P23, progress);

                Vector3 P0123 = Vector3.Lerp(P012, P123, progress);
                transform.position = P0123;
                yield return null;
            }
            movementQueue.RemoveAt(0);
        }
        isJumping = false;
    }



        //if (Input.GetKeyDown(KeyCode.A) && !isJumping)
        //{
        //    _rigidbody.useGravity = true;
        //    _rigidbody.velocity = new Vector3(-5, 0, 0);
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.left * 3, ForceMode.Impulse);
        //}
        //if (Input.GetKeyDown(KeyCode.D) && !isJumping)
        //{
        //    _rigidbody.useGravity = true;
        //    _rigidbody.velocity = new Vector3(5, 0, 0);
        //    _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //    _rigidbody.AddForce(Vector3.right * 3, ForceMode.Impulse);
        //}

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGround)
        //{
        //    startTouchPosition = Input.GetTouch(0).position;
        //}
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isGround)
        //{
        //    endTouchPosition = Input.GetTouch(0).position;
        //    if (endTouchPosition.x > startTouchPosition.x && isGround)
        //    {
        //        _rigidbody.velocity = new Vector3(5, 0, 0);
        //        _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //        _rigidbody.AddForce(Vector3.right * 3, ForceMode.Impulse);
        //    }
        //    if (endTouchPosition.x < startTouchPosition.x)
        //    {
        //        _rigidbody.velocity = new Vector3(-5, 0, 0);
        //        _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //        _rigidbody.AddForce(Vector3.left * 3, ForceMode.Impulse);
        //    }
        //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            scoreText.IncrementScore(transform.position.y);
        }
            
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
    }
}

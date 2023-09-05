using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform Player;
    public Transform PlayerTarget;
    Vector3 Target;
    public float TracingSpeed;

    void Update()
    {
        Vector3 currentPosition = Vector3.Lerp(transform.position, Target, TracingSpeed * Time.deltaTime);
        transform.position = currentPosition;
        Target = new Vector3(Player.transform.position.x + 16.55f, Player.transform.position.y + 11f, Player.transform.position.z - 17);
    }
}

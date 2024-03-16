using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyRed : MonoBehaviour, IMoveEnemy
{
    public void GetMovementPoint(ref Vector3 P0, ref Vector3 P1, ref Vector3 P2, ref Vector3 P3, ref float speed)
    {
        speed = 1f;
        P0 = transform.position;
        P1 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3f, gameObject.transform.position.z - 0.2f);
        P2 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 3f, gameObject.transform.position.z - 1.2f);
        P3 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.63f, gameObject.transform.position.z - 2.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyYelow : MonoBehaviour, IMoveEnemy
{
    bool count = false;
    public void GetMovementPoint(ref Vector3 P0, ref Vector3 P1, ref Vector3 P2, ref Vector3 P3, ref float speed)
    {
        count = !count;
        if (count == false) 
        {
            speed = 1.5f;
            P0 = transform.position;
            P1 = new Vector3(gameObject.transform.position.x + 0.4f, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z - 0.116f);
            P2 = new Vector3(gameObject.transform.position.x + 0.8f, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z - 0.6f);
            P3 = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y - 0.875f, gameObject.transform.position.z - 1.067f);
        }
        else
        {
            speed = 1.5f;
            P0 = transform.position;
            P1 = new Vector3(gameObject.transform.position.x - 0.4f, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z - 0.116f);
            P2 = new Vector3(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y + 1.5f, gameObject.transform.position.z - 0.6f);
            P3 = new Vector3(gameObject.transform.position.x - 1.2f, gameObject.transform.position.y - 0.875f, gameObject.transform.position.z - 1.067f);
        }
    }
}

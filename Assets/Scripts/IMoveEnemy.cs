using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveEnemy
{
    public void GetMovementPoint(ref Vector3 P0, ref Vector3 P1, ref Vector3 P2, ref Vector3 P3, ref float speed);
}

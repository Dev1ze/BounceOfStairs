using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    public static Vector3 StartMoving(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float progress)
    {
        Vector3 P01 = Vector3.Lerp(P0, P1, progress);
        Vector3 P12 = Vector3.Lerp(P1, P2, progress);
        Vector3 P23 = Vector3.Lerp(P2, P3, progress);

        Vector3 P012 = Vector3.Lerp(P01, P12, progress);
        Vector3 P123 = Vector3.Lerp(P12, P23, progress);

        Vector3 P0123 = Vector3.Lerp(P012, P123, progress);
        return P0123;
    }
}

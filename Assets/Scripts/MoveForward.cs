using UnityEngine;

public class MoveForward : IMove
{
    public void GetMovementPoints(Transform Player, ref Vector3 P0, ref Vector3 P1, ref Vector3 P2, ref Vector3 P3)
    {
        P0 = Player.transform.position;
        P1 = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.729f, Player.transform.position.z + 0.116f);
        P2 = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.729f, Player.transform.position.z + 0.6f);
        P3 = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.875f, Player.transform.position.z + 1.0725f);
    }
}
using UnityEngine;

public class MoveLeft : IMove
{
    public void GetMovementPoints(Transform Player, ref Vector3 P0, ref Vector3 P1, ref Vector3 P2, ref Vector3 P3)
    {
        P0 = Player.transform.position;
        P1 = new Vector3(Player.transform.position.x - 0.116f, Player.transform.position.y + 0.6f, Player.transform.position.z);
        P2 = new Vector3(Player.transform.position.x - 0.600f, Player.transform.position.y + 0.6f, Player.transform.position.z);
        P3 = new Vector3(Player.transform.position.x - 1.072f, Player.transform.position.y, Player.transform.position.z);
    }
}

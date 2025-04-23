using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static Vector3 LastCheckpoint { get; private set; }

    public static void SetCheckpoint(Vector3 position)
    {
        LastCheckpoint = position;
    }

    public static void RespawnPlayer(GameObject player)
    {
        if (LastCheckpoint != Vector3.zero)
        {
            player.transform.position = LastCheckpoint;
        }
    }
}
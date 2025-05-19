using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject deadPlayerPrefab;
    public GameObject deadPlayerInstance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area. Spawning dead player.");
            deadPlayerInstance = Instantiate(deadPlayerPrefab, player.transform.position, Quaternion.identity);
            Destroy(player);
        }
    }
}

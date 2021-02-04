using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerBehaviour>();
            player.controller.enabled = false;
            player.transform.position = spawnPoint.position;
            player.controller.enabled = true;
        }
    }
}

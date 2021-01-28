using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("DeathPlaneController: Collision with Player");

            //CharacterController doesn't allow to set trasform.position, so we need to disable it first
            var player = other.gameObject.GetComponent<PlayerBehavior>();
            player.controller.enabled = false;

            other.gameObject.transform.position = spawnPoint.position;

            player.controller.enabled = true;
        }
    }
}

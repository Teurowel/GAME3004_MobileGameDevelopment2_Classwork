using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Canvas healthBarCanvas;
    private GameObject playerCamera;
    private Camera worldCamera;

    // Start is called before the first frame update
    void Start()
    {
        healthBarCanvas = GetComponent<Canvas>();

        playerCamera = GameObject.Find("PlayerCamera");

        if(playerCamera)
        {
            worldCamera = playerCamera.GetComponent<Camera>();
        }


        healthBarCanvas.worldCamera = worldCamera;
    }

    // Using LateUpdate for Billboarding
    void LateUpdate()
    {
        if(worldCamera)
        {
            transform.LookAt(transform.position + worldCamera.transform.forward);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        var width = Screen.width * 0.5f;
        var height = Screen.height * 0.5f;


        GUI.Box(new Rect(width * 0.5f, 10.0f, width, height), "Statistics go here");

        GUI.Label(new Rect(width - 50.0f, 50.0f, 100.0f, 30.0f), "Data goes here");

        if (GUI.Button(new Rect(width - 50.0f, 100.0f, 100.0f, 30.0f), "Start"))
        {
            SceneManager.LoadScene("Main");
        }

        
    }
}

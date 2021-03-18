using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class ControlPanel : MonoBehaviour
{
    public List<MonoBehaviour> scripts;
    public List<NavMeshAgent> agents;
    public bool isGamePaused = false;
    public GameObject pauseLabelPanel;

    public PlayerBehaviour player;
    public PlayerDataSO playerData;

    // Start is called before the first frame update
    void Start()
    {


        //Add all nav mesh agent
        agents = FindObjectsOfType<NavMeshAgent>().ToList();
        
        //Add all enemy behaviour
        foreach (var enemy in FindObjectsOfType<EnemyBehaviour>())
        {
            scripts.Add(enemy);
        }

        player = FindObjectOfType<PlayerBehaviour>();
        scripts.Add(player);
        scripts.Add(FindObjectOfType<CameraController>());

        LoadFromPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseButtonToggled()
    {
        isGamePaused = !isGamePaused;
        pauseLabelPanel.SetActive(isGamePaused);

        foreach (var script in scripts)
        {
            script.enabled = !isGamePaused;
        }

        foreach(var agent in agents)
        {
            agent.enabled = !isGamePaused;
        }
    }

    public void OnLoadButtonPressed()
    {
        player.controller.enabled = false;

        player.transform.position = playerData.playerPosition;
        player.transform.rotation = playerData.playerRotation;
        player.health = playerData.playerHealth;

        player.controller.enabled = true;
    }

    public void OnSaveButtonPressed()
    {
        playerData.playerPosition = player.transform.position;
        playerData.playerRotation = player.transform.rotation;
        playerData.playerHealth = player.health;

        SaveToPrefs();
    }

    public void LoadFromPrefs()
    {
        playerData.playerPosition.x = PlayerPrefs.GetFloat("playerPositionX");
        playerData.playerPosition.y = PlayerPrefs.GetFloat("playerPositionY");
        playerData.playerPosition.z = PlayerPrefs.GetFloat("playerPositionZ");


        playerData.playerRotation.x = PlayerPrefs.GetFloat("playerRotationX");
        playerData.playerRotation.y = PlayerPrefs.GetFloat("playerRotationY");
        playerData.playerRotation.z = PlayerPrefs.GetFloat("playerRotationZ");
        playerData.playerRotation.w = PlayerPrefs.GetFloat("playerRotationW");

        playerData.playerHealth = PlayerPrefs.GetInt("playerHealth");

    }

    public void SaveToPrefs()
    {
        PlayerPrefs.SetFloat("playerPositionX", playerData.playerPosition.x);
        PlayerPrefs.SetFloat("playerPositionY", playerData.playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionZ", playerData.playerPosition.z);

        PlayerPrefs.SetFloat("playerRotationX", playerData.playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", playerData.playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", playerData.playerRotation.z);
        PlayerPrefs.SetFloat("playerRotationW", playerData.playerRotation.w);

        PlayerPrefs.SetInt("playerHealth", playerData.playerHealth);

        PlayerPrefs.Save();
    }
}

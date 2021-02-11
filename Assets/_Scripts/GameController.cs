using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public Transform TileParent;

    public List<GameObject> Tiles;
    public int depth;
    public int width;
    

    // Start is called before the first frame update
    void Start()
    {
        _buildMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void _buildMap()
    {
        for(int row = 0; row < depth; row++)
        {
            for(int col = 0; col < width; col++)
            {
                var randomTileIndex = Random.Range(0, Tiles.Count);
                var randomRotationIndex = Random.Range(0, 4);

                var randomTile = Instantiate(Tiles[randomTileIndex], new Vector3(row * 16.0f, 0.0f, col * 16.0f), Quaternion.Euler(-90.0f, randomRotationIndex * 90.0f, 0.0f));
                randomTile.transform.parent = TileParent;
            }
        }
    }

    private void OnGUI()
    {
        var scene = SceneManager.GetActiveScene();
        if (scene.name == "Start")
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
}

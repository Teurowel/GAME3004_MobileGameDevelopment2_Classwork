using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    //Player tranform properties
    [Header("Player Transform")]
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    //Player attributes
    [Header("Player Attributes")]
    public int playerHealth;
}

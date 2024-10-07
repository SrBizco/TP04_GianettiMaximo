using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSo", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerDataSo : ScriptableObject
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int health = 3;
    public GameObject defeatPanel;
    public GameObject victoryPanel;
}
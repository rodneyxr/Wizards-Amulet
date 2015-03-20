using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject debugLight;
    public Enemy[] enemies;
    public Player player;

    private const float tileSize = 5f;
    public static float TileSize { get { return tileSize; } }

    void Start() {
        debugLight.SetActive(false); // Debug light
        player.YourTurn();
    }

    void Update() {
        if (!player.PlayerTurn) {
            NotifyAllEnemies();
            player.YourTurn();
        }
    }

    void NotifyAllEnemies() {
        foreach (Enemy e in enemies) {
            e.StartTurn();
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject debugLight;
    private Enemy[] enemies;
    private Player player;

    private const float tileSize = 5f;
    public static float TileSize { get { return tileSize; } }

    void Start() {
        debugLight.SetActive(false); // Debug light
        setAllEnemies();
        //player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        if (player == null) {
            Transform startTile = GameObject.FindGameObjectWithTag("Respawn").transform;
            GameObject o = Instantiate(Resources.Load("Prefabs/Player"), startTile.position, startTile.rotation) as GameObject;
            player = o.GetComponent<Player>();
        }
        player.StartTurn();
    }

    void Update() {
        if (!player.PlayerTurn) {
            NotifyAllEnemies();
            player.StartTurn();
        }
    }

    void NotifyAllEnemies() {
        if (enemies == null) return;
        foreach (Enemy e in enemies) {
            e.StartTurn();
        }
    }

    public void setAllEnemies() {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new Enemy[list.Length];
        int count = 0;
        foreach (GameObject g in list) {
            enemies[count] = g.GetComponent<Enemy>();
            count++;
        }

    }
}

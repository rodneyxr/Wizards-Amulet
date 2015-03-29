using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject debugLight;
    private Enemy[] enemies;
    public Player player;

    private const float tileSize = 5f;
    public static float TileSize { get { return tileSize; } }

    void Start() {
        debugLight.SetActive(false); // Debug light
		setAllEnemies();
		player = GameObject.Find("Player(Clone)").GetComponent<Player>();
		player.YourTurn();
    }

    void Update() {
		if(player == null) player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        if (!player.PlayerTurn) {
            NotifyAllEnemies();
            player.YourTurn();
        }
    }

    void NotifyAllEnemies() {

		//if(enemies.Length > 0 && enemies[0] != null)
		if (enemies == null) {
			print ("enemies is null");
			return;		
		}
		foreach (Enemy e in enemies) {
            e.StartTurn();
        }
    }

	public void setAllEnemies(){
		GameObject[] list = GameObject.FindGameObjectsWithTag("Enemy");
		enemies = new Enemy[list.Length];
		int count = 0;
		foreach (GameObject g in list) {
			enemies[count] = g.GetComponent<Enemy>();
			count++;
		}

	}
}

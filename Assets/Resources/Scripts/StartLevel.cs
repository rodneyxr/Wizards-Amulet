using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour {
    string level;
    string direction;

    public void newLevel(string level, string direction) {
        this.level = level;
        this.direction = direction;
        StartCoroutine("StartNewLevel");
    }

    public IEnumerator StartNewLevel() {
        string tile = "StartTile";
        if (direction.Equals("EndTile"))
            tile = direction;

        GameObject player = GameObject.Find("Player(Clone)");
        GameObject canvas = GameObject.Find("Canvas(Clone)");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvas);
        yield return new WaitForSeconds(0.3f);
        Application.LoadLevel(level);

        yield return new WaitForSeconds(0.5f);

        GameObject startTile = GameObject.Find(tile);
        if (startTile != null) {
            player.transform.position = new Vector3(startTile.transform.position.x, player.transform.position.y, startTile.transform.position.z);
            player.transform.rotation = startTile.transform.rotation;
            player.GetComponent<PlayerStats>().updateTextReference();
            player.GetComponent<Player>().updateTextReference();
            gameObject.GetComponent<GameManager>().setAllEnemies();
        } else {
            print("start tile is null");
        }
    }
}

using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public static float tileSize = 5f;
    public GameObject debugLight;

    private bool playerTurn;

    void Start() {
        debugLight.SetActive(false); // Debug light
        playerTurn = true;
    }

    void Update() {
        if (!playerTurn) {
            print("AI move.");
        }
    }
}

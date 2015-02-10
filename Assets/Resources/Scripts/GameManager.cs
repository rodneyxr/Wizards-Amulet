using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject debugLight;

    private const float tileSize = 5f;
    public static float TileSize { get { return tileSize; } }

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

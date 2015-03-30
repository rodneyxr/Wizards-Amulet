using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
    public string direction;
    public string level;

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            StartLevel s = GameObject.Find("_Main(Clone)").GetComponent<StartLevel>();
            s.newLevel(level, direction);
        }
    }
}
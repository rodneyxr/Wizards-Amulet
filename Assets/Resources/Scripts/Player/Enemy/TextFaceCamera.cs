using UnityEngine;
using System.Collections;

public class TextFaceCamera : MonoBehaviour {

    void Update() {
        if (Camera.main == null) return;
        // Credits to Fabkins
        Vector3 v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(Camera.main.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}

using UnityEngine;
using System.Collections;

public class TextFaceCamera : MonoBehaviour {

    private Transform cameraToLookAt;

    void Start() {
        cameraToLookAt = Camera.main.transform;
    }

    
    void Update() {
        // Credits to Fabkins
        Vector3 v = cameraToLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(cameraToLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}

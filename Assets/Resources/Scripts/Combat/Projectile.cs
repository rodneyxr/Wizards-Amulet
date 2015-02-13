using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour {

    public float range = 10.0f; // how many tiles the projectile will travel before dying
    public float speed = 10.0f; // how fast the projectile will travel
    protected Vector3 startPosition;

    public void Start() {
        startPosition = transform.position;
    }

    void Update() {
		if (this.gameObject.tag == "Fire" && Vector3.Distance (startPosition, transform.position) > range * GameManager.TileSize * .3) {
			this.gameObject.GetComponent<ParticleSystem>().emissionRate /= 25; 
		}
		if (Vector3.Distance(startPosition, transform.position) > range * GameManager.TileSize) {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        hit(other);
    }

    public abstract void hit(Collider other);
}

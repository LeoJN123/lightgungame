using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blasterbullet : MonoBehaviour {

    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    public Rigidbody rb;

    private void Start() {
        Destroy(gameObject, lifeTime);
    }

    private void Awake() {
        rb.AddForce(transform.forward * bulletSpeed * 10);
    }

    void Wallhit () {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        Wallhit();
    }
}

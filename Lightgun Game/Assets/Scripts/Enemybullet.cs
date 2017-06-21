using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour {

    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] float bulletDamage;
    public Rigidbody rb;

    private void Start() {
        Destroy(gameObject, lifeTime);
    }

    private void Awake() {
        rb.AddForce(transform.forward * bulletSpeed * 10);
    }

    void BulletDestroy () {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        BulletDestroy();
    }
}

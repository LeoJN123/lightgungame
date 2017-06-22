﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blasterbullet : MonoBehaviour {

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

    void Wallhit () {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Enemy") {
            coll.GetComponentInParent<Enemy>().TakeDamage(bulletDamage);
        }
        Wallhit();
    }

    private void OnCollisionEnter(Collision collision) {
        Wallhit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum enemyTier {blue, red, pink};

    public enemyTier enemyLevel;
    public float speed;

    public GameObject player;
    Vector3 direction;
    Vector3 playerLocation;
    Rigidbody rb;

    //Ignore these
    

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        var v = rb.velocity;
        var pp = player.transform.position;
        var d = (pp - transform.position).normalized;
        v = v + d * speed * Time.fixedDeltaTime;
        rb.velocity = v;

        if (enemyLevel == enemyTier.blue) {

        }

        if (enemyLevel == enemyTier.red) {

        }

        if (enemyLevel == enemyTier.pink) {

        }
    }
}

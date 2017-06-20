using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum enemyTier {blue, red, pink};

    public enemyTier enemyLevel;
    public float speed;
    public float circleDistance;
    public float health;

    GameObject player;
    Rigidbody rb;

    //Ignore these
    Vector3 playerPos;
    Vector3 direction;
    Vector3 enemyVelocity;

    private void Awake() {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        if (Vector3.Distance(transform.position, playerPos) > circleDistance) {
            MoveTowardsPlayer();
        }     

        if (enemyLevel == enemyTier.blue) {

        }

        if (enemyLevel == enemyTier.red) {

        }

        if (enemyLevel == enemyTier.pink) {

        }
    }

    void MoveTowardsPlayer () {
        enemyVelocity = rb.velocity;
        playerPos = player.transform.position;
        direction = (playerPos - transform.position).normalized;
        enemyVelocity = enemyVelocity + direction * speed * Time.fixedDeltaTime;
        rb.velocity = enemyVelocity;
    }

    void TakeDamage(float damage) {
        health--;
        if (health < 0) {
            Death();
        }
    }

    public void Death () {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        TakeDamage(10);
    }
}

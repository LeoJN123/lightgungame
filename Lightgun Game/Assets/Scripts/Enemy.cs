using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public enum enemyTier {blue, red, pink};

    public enemyTier enemyLevel;
    public float speed;
    public float circleDistance;
    public float health;
    public float deathExplosionForce;
    public float shootInterval;
    public float dodgeSpeed;
    public float dodgeInterval;

    public AudioSource audioS;
    public AudioClip deathSfx;
    public AudioClip damageSfx;
    public AudioClip fireSfx;
    public ParticleSystem partFx;
    public GameObject bullet;


    GameObject player;
    Rigidbody rb;

    //Ignore these
    Vector3 playerPos;
    Vector3 direction;
    Vector3 enemyVelocity;

    private void Awake() {
        if (GameObject.Find("VRCamera") == null) {
            player = GameObject.Find("FollowHead");
        } else {
            player = GameObject.Find("VRCamera");
        }
        rb = GetComponent<Rigidbody>();
        partFx.Pause();
        StartCoroutine(FiringAI());
        StartCoroutine(DodgeAI());
    }

    private void FixedUpdate() {

        if (Vector3.Distance(transform.position, playerPos) > circleDistance) {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer () {
        enemyVelocity = rb.velocity;
        playerPos = player.transform.position;
        direction = (playerPos - transform.position).normalized;
        enemyVelocity = enemyVelocity + direction * speed * Time.fixedDeltaTime;
        rb.velocity = enemyVelocity;
    }

    public void TakeDamage(float damageToUs) {
        
        if (health <= damageToUs) {
            Death();
        } else {
            PlaySound(damageSfx);
            health -= damageToUs;
            partFx.Play();
        }
        
        
    }

    public void Death () {
        StartCoroutine(DeathSequence());
    }

    void Fire() {
        Instantiate(bullet, transform.position, Quaternion.LookRotation(direction, Vector3.up) , gameObject.transform);
        audioS.PlayOneShot(fireSfx);
    }

    IEnumerator FiringAI() {
        while (true) {
            yield return new WaitForSeconds(shootInterval + Random.Range(0,3));
            Fire();
        }
    }

    IEnumerator DodgeAI() {
        while (true) {
            yield return new WaitForSeconds(dodgeInterval);
            rb.AddForce(Random.onUnitSphere * dodgeSpeed, ForceMode.Impulse);
        }
    }

    IEnumerator DeathSequence() {
        StopCoroutine(FiringAI());
        StopCoroutine(DodgeAI());
        rb.useGravity = true;
        PlaySound(deathSfx);
        rb.AddForce(Random.onUnitSphere * deathExplosionForce, ForceMode.Impulse );
        rb.AddTorque(Random.onUnitSphere * deathExplosionForce, ForceMode.Impulse);
        partFx.Play();
        yield return new WaitForSeconds(shootInterval);
        Destroy(gameObject);
        yield break;
    }

    void PlaySound (AudioClip aud) {
        audioS.pitch = Random.Range(0.75f, 1.25f);
        audioS.PlayOneShot(aud);
    }
}

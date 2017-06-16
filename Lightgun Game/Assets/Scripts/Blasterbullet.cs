using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blasterbullet : MonoBehaviour {

    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;

    private void Start() {
        Destroy(gameObject, lifeTime);
    }

    private void Update() {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}

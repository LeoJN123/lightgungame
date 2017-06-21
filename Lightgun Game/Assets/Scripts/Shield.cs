using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

    public UnityEvent shieldHit;

    private void OnTriggerEnter(Collider other) {
        print("Shield hit something!");
        shieldHit.Invoke();
    }

}

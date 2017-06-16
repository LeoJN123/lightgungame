using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class Blaster : MonoBehaviour {

    public GameObject muzzle;
    public GameObject bullet;

    private void HandAttachedUpdate (Hand hand) {

#if UNITY_EDITOR
        if (hand.controller == null && hand.GetStandardInteractionButtonDown()) {//debug shoot
            Shoot();
            return;
        }
#endif

        if (hand.controller != null && hand.controller.GetHairTriggerDown()) {
            Shoot();
        }
    }

    private void Shoot () {
        Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
    }
}
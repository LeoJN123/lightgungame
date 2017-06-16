using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class gunBehaviour : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;
    public ushort hapticPulseDuration = 500;

    //Called from Hand
    private void HandAttachedUpdate(Hand hand) {
#if UNITY_EDITOR
        if (hand.controller == null && hand.GetStandardInteractionButtonDown()) {//debug shoot
            //debug shoot function
            return;
        }
#endif

        if (hand.controller != null && hand.controller.GetHairTriggerDown()) {//normal shoot
            //shoot function

        }
    }

    private void Shoot(Hand hand) {
        
    }
    

    //Called from Hand
    private void OnDetachedFromHand(Hand hand) {
        Destroy(gameObject);
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class Blaster : MonoBehaviour {

    public GameObject muzzle;
    public GameObject bullet;
    public AudioSource fireAudioSource;
    public AudioClip blasterFire;

    public float fireInterval;

    bool canFire = true;

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
        if (canFire) {
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            PlaySound(blasterFire);
            canFire = false;
            StartCoroutine(FirePause());
        }

    }

    IEnumerator FirePause() {
        yield return new WaitForSeconds(fireInterval);
        canFire = true;
        yield return null;
    }

    void PlaySound(AudioClip aud) {
        fireAudioSource.pitch = UnityEngine.Random.Range(0.75f, 1.25f);
        fireAudioSource.PlayOneShot(aud);
    }
}
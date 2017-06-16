using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;
    public ushort hapticPulseDuration = 500;
    public Renderer magazineRenderer;
    public UnityEvent onShootEvent, onNoAmmoEvent, onReloadEvent;

    private int bulletsPerMag = 8, bullets;

    internal bool NeedAmmo()
    {
        return bullets == 0;
    }

    private void Start()
    {
        bullets = bulletsPerMag;
    }

    //Called from Hand
    private void HandAttachedUpdate(Hand hand)
    {
#if UNITY_EDITOR
        if (hand.controller == null && hand.GetStandardInteractionButtonDown())
        {//debug shoot
            Shoot(null);
            return;
        }
#endif

        if (hand.controller != null && hand.controller.GetHairTriggerDown())
        {//normal shoot
            Shoot(hand);
            
        }
    }

    private void Shoot(Hand hand)
    {
        if (bullets > 0)
        {
            bullets--;
            if (bullets == 0)
                magazineRenderer.enabled = false;

            Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            onShootEvent.Invoke();
            if (hand)
                hand.controller.TriggerHapticPulse(hapticPulseDuration);
        }
        else
        {
            onNoAmmoEvent.Invoke();
        }
    }

    public void Reload(GunMagazine magazine)
    {
        bullets = bulletsPerMag;
        magazineRenderer.enabled = true;

        onReloadEvent.Invoke();
    }

    //Called from Hand
    private void OnDetachedFromHand(Hand hand)
    {
        Destroy(gameObject);
    }
    
}

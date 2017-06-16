using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GunMagazine : MonoBehaviour {

    private Hand hand;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GunMagazineTrigger")
        {
            var gun = other.GetComponentInParent<Gun>();

            if (gun.NeedAmmo())
            {
                other.GetComponentInParent<Gun>().Reload(this);
				hand.DetachObject(gameObject, false);
				Destroy(gameObject);
            }
        }
    }

    //-------------------------------------------------
    private void OnAttachedToHand(Hand attachedHand)
    {
        hand = attachedHand;
    }
}

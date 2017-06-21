using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR.InteractionSystem;

public class MovementScript : MonoBehaviour
{
    public LayerMask floor;
    public LayerMask enemy;
    public GameObject player;
    // Update is called once per frame

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, fwd, out hit))
            Debug.DrawLine(transform.position, hit.point);


    }
    private void HandAttachedUpdate(Hand hand)
    {
        RaycastHit hit;
        Vector3 dwn = transform.TransformDirection(Vector3.down);
        if (hand.controller != null && hand.controller.GetHairTriggerDown() && Physics.Raycast(transform.position, dwn, out hit))
        {
            player.transform.Translate(hit.point);
        }
    }
}
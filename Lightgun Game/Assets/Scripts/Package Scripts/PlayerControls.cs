using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerControls : MonoBehaviour
{
    public Hand hand1, hand2;
    bool slowdown = false;
    public float slowDownScale = 0.5f;

	void Update ()
    {
        if ((hand1.controller != null && hand1.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)) || (hand2.controller != null && hand2.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)) || Input.GetKeyDown(KeyCode.Space)) 
        {
            slowdown = !slowdown;
            Time.timeScale = slowdown ? slowDownScale : 1f;
        }

	}
}

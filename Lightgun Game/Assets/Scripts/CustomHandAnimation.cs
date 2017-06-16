using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CustomHandAnimation : MonoBehaviour 
{
	public Animator animator;
	private Hand hand;

	private void Start()
	{
		hand = GetComponentInParent<Hand> ();
	}
		
	private void Update()
	{
		if (hand.controller != null)
		{
			animator.SetBool ("Grab", hand.controller.GetHairTrigger());
		}
	}
}
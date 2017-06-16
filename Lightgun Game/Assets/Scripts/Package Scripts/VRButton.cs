using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.Events;


[RequireComponent(typeof(Interactable))]
public class VRButton : MonoBehaviour
{
    public string hintText = "";
    public bool requireTriggerPressToUse = true;
    public UnityEvent onPressedEvent;

    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        if (requireTriggerPressToUse && hintText != "")
        {
            ControllerButtonHints.ShowTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, hintText);
        }
    }

    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        if (requireTriggerPressToUse)
        {
#if UNITY_EDITOR
                if (hand.controller == null && hand.GetStandardInteractionButtonDown())
                {
                    PressButton();
                }
#endif

            if (hand.controller != null && hand.controller.GetHairTriggerDown())
            {
                PressButton();
            }
        }
    }

    private void PressButton()
    {
        onPressedEvent.Invoke();
    }


    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        if (requireTriggerPressToUse && hintText != "")
        {
            ControllerButtonHints.HideTextHint(hand, Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);
        }
    }
}

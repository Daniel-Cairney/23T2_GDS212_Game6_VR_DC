using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
namespace DanielCairney
{
    public class ControllerTPController : MonoBehaviour
    {
        public XRController leftTeleportRay;
        public InputHelpers.Button teleportActivationButton;
        public float activationThreshold = 0.1f;


        void Update()
        {
            if (leftTeleportRay)
            {
                leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay));
            }
        }

        public bool CheckIfActivated(XRController controller)
        {
            InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
            return isActivated;
        }
    }
}

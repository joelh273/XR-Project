using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement2 : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;

    private void Update()
    {
        if (MainCube2.interactable)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp))
            {
                GetComponent<Rigidbody>().velocity += moveDirection;
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
            {
                GetComponent<Rigidbody>().velocity -= moveDirection;
            }
        }
    }
}

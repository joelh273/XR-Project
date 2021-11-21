using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement2 : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;

    private void Update()
    {
        if (MainCube2.interactable)
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
            {
                GetComponent<Rigidbody>().velocity -= moveDirection;
            }
            if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
            {
                GetComponent<Rigidbody>().velocity += moveDirection;
            }
        }
    }
}

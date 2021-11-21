using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCube2 : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject grabCube;
    public static bool interactable = false;

    private void Update()
    {
        if (interactable)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End2"))
        {
            Debug.Log("trigger 2 on");
            grabCube.SetActive(true);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void setInteractable(bool value)
    {
        interactable = value;
    }
}

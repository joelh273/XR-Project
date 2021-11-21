using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCube : MonoBehaviour
{
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;
    private Vector3 leftEndPosition;
    private Vector3 rightEndPosition;
    private bool trigger = false;
    public static bool interactable = false;

    private void Awake()
    {
        leftEndPosition = new Vector3(doorLeft.transform.position.x + 3.0f, doorLeft.transform.position.y, doorLeft.transform.position.z);
        rightEndPosition = new Vector3(doorRight.transform.position.x - 3.0f, doorRight.transform.position.y, doorRight.transform.position.z);
    }
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
        
        if (trigger)
        {
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftEndPosition, 0.1f);
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightEndPosition, 0.1f);
            if (doorLeft.transform.position == leftEndPosition && doorRight.transform.position == rightEndPosition)
            {
                trigger = false;
                doorLeft.SetActive(false);
                doorRight.SetActive(false);
                Debug.Log("trigger off");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("End1"))
        {
            Debug.Log("trigger 1 on");
            trigger = true;
            FindObjectOfType<AudioManager>().Play("Door");
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public void setInteractable(bool value)
    {
        interactable = value;
    }
}

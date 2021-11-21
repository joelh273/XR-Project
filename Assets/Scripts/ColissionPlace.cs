using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionPlace : MonoBehaviour
{
    [SerializeField] GameObject collisionObject;
    private bool moveDoors = false;
    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;
    private Vector3 leftEndPosition;
    private Vector3 rightEndPosition;
    private void Awake()
    {
        leftEndPosition = new Vector3(doorLeft.transform.position.x, doorLeft.transform.position.y + 4.0f, doorLeft.transform.position.z);
        rightEndPosition = new Vector3(doorRight.transform.position.x, doorRight.transform.position.y + 4.0f, doorRight.transform.position.z);
    }

    private void Update()
    {
        if (moveDoors)
        {
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftEndPosition, 0.1f);
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightEndPosition, 0.1f);
            if (doorLeft.transform.position == leftEndPosition && doorRight.transform.position == rightEndPosition)
            {
                moveDoors = false;
                Debug.Log("trigger off");
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == collisionObject)
        {
            moveDoors = true;
            FindObjectOfType<AudioManager>().Play("Door");
        }
    }
}

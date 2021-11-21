using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ButtonScript : MonoBehaviour
{

    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject doorRight;
    [SerializeField] Material newMaterial;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject videoCover;
    private Vector3 leftEndPosition;
    private Vector3 rightEndPosition;
    private bool buttonPressed = false;

    private void Awake()
    {
        leftEndPosition = new Vector3(doorLeft.transform.position.x, doorLeft.transform.position.y - 4f, doorLeft.transform.position.z);
        rightEndPosition = new Vector3(doorRight.transform.position.x, doorRight.transform.position.y - 4f, doorRight.transform.position.z);
    }

    private void Update()
    {
        if (buttonPressed)
        {
            doorLeft.transform.position = Vector3.Lerp(doorLeft.transform.position, leftEndPosition, 0.1f);
            doorRight.transform.position = Vector3.Lerp(doorRight.transform.position, rightEndPosition, 0.1f);
            if (doorLeft.transform.position == leftEndPosition && doorRight.transform.position == rightEndPosition)
            {
                buttonPressed = false;
                videoCover.SetActive(false);
                videoPlayer.Play();
                Debug.Log("trigger off");
            }
        }
    }

    public void onButtonPressed()
    {
        Debug.Log("button pressed");
        buttonPressed = true;
        gameObject.GetComponent<MeshRenderer>().material = newMaterial;
        FindObjectOfType<AudioManager>().Play("Door");
        FindObjectOfType<AudioManager>().Stop("Theme");
    }
}

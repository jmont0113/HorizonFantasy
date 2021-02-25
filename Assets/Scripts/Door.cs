using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    bool openedDoor;
    public AudioSource doorOpeningSound;
    public AudioSource doorClosingSound;
    public void OpenDoor()
    {
        if(openedDoor)
        {
            // transform.Rotate(0f, 90f, 0f);
            transform.Rotate(0f, 0f, 180f);
            doorOpeningSound.Play();
        }
        else
        {
            // transform.Rotate(0f, -90f, 0f);
            transform.Rotate(0f, 0f, -180f);
            doorClosingSound.Play();
        }
        openedDoor = !openedDoor;
    }
}

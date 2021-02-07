using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    bool openedDoor;

    public void OpenDoor()
    {
        if(openedDoor)
        {
            transform.Rotate(0f, 90f, 0f);
        }
        else
        {
            transform.Rotate(0f, -90f, 0f);
        }
        openedDoor = !openedDoor;
    }
}

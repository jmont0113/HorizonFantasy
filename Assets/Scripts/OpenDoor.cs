﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : InteractableModule
{
    [SerializeField]
    Door door;
    public AudioSource leverSound;

    public override void Interact(GameObject actor)
    {
        door.OpenDoor();
        leverSound.Play();
    }
}

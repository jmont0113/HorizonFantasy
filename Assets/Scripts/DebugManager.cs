﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public GameObject guiCanvas;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            guiCanvas.SetActive(guiCanvas.activeInHierarchy);
        }
    }
}

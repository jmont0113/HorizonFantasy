using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (CheckFreeze()) return;
    }

    public bool CheckFreeze()
    {
        bool b;

        if (DialoguesManager.instance.inDialogue)
        {
            b = true;
        }
        else
        {
            b = false;
        }

        return b;
    }
}

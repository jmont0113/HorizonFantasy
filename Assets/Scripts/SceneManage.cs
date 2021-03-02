using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject overWorld;

    public void Set(bool b)
    {
        overWorld.SetActive(b);
    }
}

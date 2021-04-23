using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimate : MonoBehaviour
{
    public GameObject titleName;

    public GameObject loadingSpin01;
    public GameObject loadingSpin02;
    public GameObject loadingSpin03;
    public GameObject loadingSpin04;


    void Start()
    {
        LeanTween.scale(titleName, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();
        LeanTween.rotate(loadingSpin01, new Vector3(0, 0, 180), 1f).setEaseOutCirc().setLoopCount(5);
        LeanTween.rotate(loadingSpin02, new Vector3(0, 0, 180), 1f).setEaseOutCirc().setLoopCount(5);
        LeanTween.rotate(loadingSpin03, new Vector3(0, 0, 180), 1f).setEaseOutCirc().setLoopCount(5);
        LeanTween.rotate(loadingSpin04, new Vector3(0, 0, 180), 1f).setEaseOutCirc().setLoopCount(5);
    }
}

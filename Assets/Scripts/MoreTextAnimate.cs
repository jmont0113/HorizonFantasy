using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreTextAnimate : MonoBehaviour
{
    public GameObject text01;
    public GameObject text02;
    public GameObject actionButton;

    public GameObject text03;
    public GameObject text04;

    public GameObject winButton;

    public GameObject gameOverButton;

    public GameObject arrow;

    void Start()
    {
        LeanTween.scale(text01, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();
        LeanTween.scale(text02, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();
        LeanTween.scale(actionButton, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();

        LeanTween.scale(text03, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();
        LeanTween.scale(text04, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();

        LeanTween.scale(winButton, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();

        LeanTween.scale(gameOverButton, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();

        LeanTween.scale(arrow, new Vector3(0.75f, 0.75f, 0.75f), 1f).setEaseLinear().setLoopPingPong();
    }
}

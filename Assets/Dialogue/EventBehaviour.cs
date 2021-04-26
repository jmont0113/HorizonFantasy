using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent01()
    {
        Debug.Log("Test event 01 successful");
        Destroy(References.instance.testGameObject);
        //any logic here
    }

    public void TestEvent02()
    {
        Debug.Log("Test event 02 successful");
        //any logic here
    }

    public void TestEvent03()
    {
        Debug.Log("Test event 03 successful");
        //any logic here
    }

    public void TestEvent04()
    {
        Debug.Log("Test event 04 successful");
        //any logic here
    }
}

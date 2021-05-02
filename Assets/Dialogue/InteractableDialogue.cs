using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDialogue : MonoBehaviour
{
    public float interactRange = 2;

    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        //code
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}

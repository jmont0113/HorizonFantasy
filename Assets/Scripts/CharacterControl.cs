using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator animator;
    new Rigidbody rigidbody;

    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float rotationSpeed = 5f;
    public GameObject target;
    Transform characterTransform;
    InteractionController interactionController;

    public AudioSource walkingSound;
    public AudioSource steppingSound;

    public void Init(GameObject newTarget)
    {
        target = newTarget;
        animator = target.GetComponent<Animator>();
        rigidbody = target.GetComponent<Rigidbody>();
        characterTransform = target.transform;
        interactionController = target.GetComponent<InteractionController>();
    }

    Vector3 motion;

    void Update()
    {
        if(target == null) { return; }

        motion = new Vector3(Input.GetAxis("Horizontal"), 0f,
            Input.GetAxis("Vertical")).normalized;
        animator.SetFloat("ForwardMotion", motion.magnitude);
        
        if (Input.GetMouseButtonDown(0))
        {
            interactionController.CheckInteract();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            GameManager.instance.guiManager.OpenInventory(true);
            GameManager.instance.SetControlScheme(ControlScheme.Inventory);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            walkingSound.Play();
            steppingSound.Play();
        }
 
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            walkingSound.Play();
            steppingSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            walkingSound.Play();
            steppingSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            walkingSound.Play();
            steppingSound.Play();
        }
    }

    private void FixedUpdate()
    {
        if (target == null) { return; }

        rigidbody.velocity = new Vector3(motion.x * moveSpeed, rigidbody.velocity.y, motion.z * moveSpeed);
        if(motion != Vector3.zero)
        {
            Vector3 newDir = Vector3.RotateTowards(characterTransform.forward, motion, rotationSpeed * Time.fixedDeltaTime, 0);
            characterTransform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}

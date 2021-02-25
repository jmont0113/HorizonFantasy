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

    public AudioSource walkingSound;
    public AudioSource steppingSound;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    Vector3 motion;

    void Update()
    {
        motion = new Vector3(Input.GetAxis("Horizontal"), 0f,
            Input.GetAxis("Vertical")).normalized;
        animator.SetFloat("ForwardMotion", motion.magnitude);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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
        rigidbody.velocity = new Vector3(motion.x * moveSpeed, rigidbody.velocity.y, motion.z * moveSpeed);
        if(motion != Vector3.zero)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, motion, rotationSpeed * Time.fixedDeltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}

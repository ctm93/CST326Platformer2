using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EthanChar : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rb;
    public float modifier = 1;
    public float jumpForce = 1;
    [Range(-2, 2)] public float speed = 0;
    private bool jump = false;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //jump = (Input.GetKeyDown(KeyCode.Space)) ? true : false;

        //horizontal = speed;

        //Set character rotation

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Quaternion newrotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = newrotation;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Quaternion newrotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = newrotation;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        }


        //Set character animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //move character
        transform.Translate(transform.forward * horizontal * modifier * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, transform.position.y, -1);

    }

    void FixedUpdate()
    {

        //if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
    }
}
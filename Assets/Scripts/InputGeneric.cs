using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGeneric : MonoBehaviour

{
    private float range = 2.1f;
    private Vector3 offset = new Vector3(0,1f,0);
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position +offset, -transform.up);
        Debug.DrawLine(transform.position + offset, transform.position +offset - transform.up * range, Color.red);
        if(Physics.Raycast(ray,  out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.layer ==3)
            {
                Debug.Log("Walkable");
                animator.SetBool("isOnGround", true);
            }
            else
            {
                animator.SetBool("isOnGround", false);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
         animator.SetBool("isRunning", false);   
        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
        

        
    }
}
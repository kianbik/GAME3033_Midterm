using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{
    public bool isCaptured;
    Rigidbody rigidbody;
    Animator followerAnimator;

    
    private void Awake()
    {
        followerAnimator = GetComponent<Animator>();
       
        rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (gameObject.tag == "Follower")
        {
            followerAnimator.SetBool("IsCaptured", true);
        }
        if (Mathf.Abs(rigidbody.velocity.y) > 5)
        {
            followerAnimator.SetBool("IsFalling", true);
        }
        if (Mathf.Abs(rigidbody.velocity.y) < 5)
        {
            followerAnimator.SetBool("IsFalling", false);
        }
    }

   

}

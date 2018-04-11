using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S07a_Trigger : MonoBehaviour {

    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isOpen", true);
    }

    void OnTriggerExit(Collider other)
    {
        animator.SetBool("isOpen", false);
    }
}

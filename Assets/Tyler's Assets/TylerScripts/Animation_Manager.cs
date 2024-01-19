using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteActuator.Combo == 0)
        {
            animator.PlayInFixedTime("ClipName", 1, 0.0f);
            animator.SetBool("if_missed", true);
            Debug.Log("ddjsdjkshkdjs");
        }
        else
            animator.SetBool("if_missed",false);
    }
}

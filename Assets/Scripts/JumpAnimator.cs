using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimator : MonoBehaviour
{
    Animator jump;
    void Start()
    {
        jump = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            jump.SetTrigger("SaltoPar");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextDialog : MonoBehaviour
{
    int index=2;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if(FirstPersonMovement.dialog)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index += 1;
                if(transform.childCount == index)
                {
                    index=2;
                    FirstPersonMovement.dialog=false;
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}

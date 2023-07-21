using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donmeDolap : MonoBehaviour
{
   
    public Animator anim;

    private void Update()
    {
        if (FreezePosition.score == 60)
        {
            anim.enabled = false;
        }
    }

}

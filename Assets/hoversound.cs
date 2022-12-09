using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoversound : MonoBehaviour
{
    public AudioSource BTSE;
    public AudioClip hoverSE;
    // Start is called before the first frame update

    public void hoverSound()
    {
        BTSE.PlayOneShot(hoverSE);
    }
}
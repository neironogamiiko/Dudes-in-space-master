using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonAudio;
    public AudioClip clicSound;

    public void ClicSound()
    {
        buttonAudio.PlayOneShot(clicSound); 
    }
}
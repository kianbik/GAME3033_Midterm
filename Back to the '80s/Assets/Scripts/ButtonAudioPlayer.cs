using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioPlayer : MonoBehaviour
{
    public AudioClip HoverClip;
    public AudioClip ClickClip;
    public AudioSource audioSource;

  public void HoverSound()
    {
        audioSource.PlayOneShot(HoverClip);
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(ClickClip);
    }
}

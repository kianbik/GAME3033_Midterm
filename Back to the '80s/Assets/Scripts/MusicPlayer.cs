using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicPlayer = new AudioClip[7];
    public AudioSource bgAudioSource;
    public int audioCounter = 1;
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bgAudioSource.isPlaying)
        {
            NextSong();
        }
        if (playerInput.actions["Skip"].triggered)
        {
            bgAudioSource.Stop();
            NextSong();
        }
    }
    public void NextSong()
    {
        
            audioCounter++;
            bgAudioSource.clip = musicPlayer[audioCounter];
            bgAudioSource.Play();
            if (audioCounter == 6)
                audioCounter = 0;
        
    }
}

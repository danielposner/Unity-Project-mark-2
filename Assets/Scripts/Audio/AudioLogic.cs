using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// This module handles the logic of importing the named audio file
// The audio strings are named identically to the image strings, except they have the word AUDIO at the end
// We load the appropriate audio from the Resources folder, then play it in our audiosource (created if there isn't one)
// The play pause is really a play/stop button. Pause was jarring so rather than pausing the audio, the pause button resets it.

[RequireComponent(typeof(AudioSource))] // If an audio source doesn't exist, create one
public class AudioLogic : MonoBehaviour
{


    AudioClip song1; // Load the audio
    public Sprite playImage;
    public Sprite pauseImage;
    public Button but; // Variables for the button

    private AudioSource audioSource;
    private bool playing;
    public string audioString; 



    // both songs are in paused state
    void Start()
    {
        audioString = PDFMenuScript.instance.audioString; // Get the relevant varaible and load it
        song1 = Resources.Load<AudioClip>(audioString); 
        audioSource = gameObject.GetComponent<AudioSource>(); 
        audioSource.clip = song1;
        playing = false; //Default audio to off
        gameObject.GetComponent<AudioSource>().clip = song1;
    }

    public void onPress()
    {
        // Cycles between play and stop. Audio changes and the image changes
        playing = !playing;


        if (playing == true)
        {
            song1 = Resources.Load<AudioClip>(audioString); // rig up the same way as other code to link all audio (rename etc)
            audioSource.clip = song1;
            gameObject.GetComponent<AudioSource>().clip = song1;

            //moving
            audioSource.Play();
            but.image.sprite = pauseImage;
            // Set image to pause
        }
        else{
            audioSource.Stop();
            but.image.sprite = playImage;
            // Set image to play
        }

    } }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidesounds : MonoBehaviour
{
    // Define the audio source and trigger collider as public variables
    public AudioSource audioSource;
    public BoxCollider triggerCollider;

    // Use the OnTriggerEnter method to detect when the player enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Play the sound
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidesounds : MonoBehaviour
{
    // definerar vilken audio som ska spelas vid collison
    public AudioSource audioSource;
    public BoxCollider triggerCollider;

    // ontrigger för att se när spelaren nuddar collidern
    private void OnTriggerEnter(Collider other)
    {
        // spelar musiken
        audioSource.Play();
    }
}

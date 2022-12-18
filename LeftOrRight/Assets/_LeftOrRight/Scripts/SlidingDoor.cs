using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{  
    // definerar hur l�ng tid det tar f�r att d�rren ska flytta sig till en viss postion 
    public float duration = 1f;
    public float loweredHeight = 1.5f;

    // om d�rren �r �ppen eller inte och vector f�r att h�lla den orginala postionen 
    private bool _lowerDoor = false;
    private Vector3 _raisedPosition;
    
    void Start()
    {
        _raisedPosition = transform.position;
    }

    public void ToggleDoorOpen() // denna del avg�r om d�rren �r �ppen eller st�ngd, denna del av koden g�r om igen s� den �ppnar och st�nger d�rren
    {
        StopAllCoroutines();
        if (!_lowerDoor)
        {
            Vector3 lowerPosition = _raisedPosition + Vector3.down * loweredHeight;
            StartCoroutine(MoveDoor(lowerPosition));
        }
        else
        {
            StartCoroutine(MoveDoor(_raisedPosition));
        }

        _lowerDoor = !_lowerDoor;
    }

    /*MoveDoor()-koroutinen anv�nder Lerp()-funktionen f�r att mjukt interpolera d�rrens 
    position fr�n den nuvarande positionen till m�lpositionen under den specificerade duration-perioden.
        Detta g�rs genom att �ka en timeElapsed-variabel med Time.deltaTime-v�rdet p� varje frame och anv�nda denna variabel f�r att ber�kna d�rrens nuvarande position l�ngs
    interpolationsv�gen. Koroutinen ger kontrollen tillbaka 
    till huvudspelsloopen p� varje frame tills duration-tiden har g�tt, vid vilket tidpunkt d�rren flyttas till den slutliga m�lpositionen.*/

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}

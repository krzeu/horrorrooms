using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{  
    // definerar hur lång tid det tar för att dörren ska flytta sig till en viss postion 
    public float duration = 1f;
    public float loweredHeight = 1.5f;

    // om dörren är öppen eller inte och vector för att hålla den orginala postionen 
    private bool _lowerDoor = false;
    private Vector3 _raisedPosition;
    
    void Start()
    {
        _raisedPosition = transform.position;
    }

    public void ToggleDoorOpen() // denna del avgör om dörren är öppen eller stängd, denna del av koden går om igen så den öppnar och stänger dörren
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

    /*MoveDoor()-koroutinen använder Lerp()-funktionen för att mjukt interpolera dörrens 
    position från den nuvarande positionen till målpositionen under den specificerade duration-perioden.
        Detta görs genom att öka en timeElapsed-variabel med Time.deltaTime-värdet på varje frame och använda denna variabel för att beräkna dörrens nuvarande position längs
    interpolationsvägen. Koroutinen ger kontrollen tillbaka 
    till huvudspelsloopen på varje frame tills duration-tiden har gått, vid vilket tidpunkt dörren flyttas till den slutliga målpositionen.*/

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

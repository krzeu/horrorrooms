using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    public float deadTime = 1.0f;

    private bool _deadTimeActive = false;
    [SerializeField]
    public UnityEvent onPressed, onReleased;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("i have been pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("i have been released");
            StartCoroutine(WaitForDeadTime());
        }


        IEnumerator WaitForDeadTime()
        {
            _deadTimeActive = true;
            yield return new WaitForSeconds(deadTime);
            _deadTimeActive = false;
        }



    }

}
/* Detta kod är för en knapp i ett spel eller en applikation som kan tryckas och släppas, och som har en konfigurerbar "dödstid" under vilken den inte kan tryckas igen.
Koden definierar en publik deadTime-fält som specificerar längden på dödstiden i sekunder, och ett privat _deadTimeActive-booleskt fält som håller reda på om knappen för närvarande 
är i dödstiden. Den definierar också två publika UnityEvent-fält, onPressed och onReleased, som kan användas för att specificera åtgärder som ska vidtas när knappen trycks eller släpps.
Koden har två OnTriggerEnter()- och OnTriggerExit()-funktioner, som kallas när ett annat objekt kommer in eller lämnar triggerns kolliderare som är ansluten till knappobjektet. 
Dessa funktioner kontrollerar om det objekt som kommer in eller går ut har en "Button"-tagg och om dödstiden för närvarande är aktiv. Om båda dessa villkor är uppfyllda, anropas onPressed- eller onReleased-händelsen och ett debugmeddelande loggas till konsolen.
När OnTriggerExit()-funktionen anropas startar den också en koroutine som heter WaitForDeadTime(), som sätter _deadTimeActive-fältet till true och väntar sedan på den
specificerade deadTime-perioden innan den sätts tillbaka till false. Detta hindrar knappen från att tryckas igen tills dödstiden har gått.*/




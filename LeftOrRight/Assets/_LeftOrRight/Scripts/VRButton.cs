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
/* Detta kod �r f�r en knapp i ett spel eller en applikation som kan tryckas och sl�ppas, och som har en konfigurerbar "d�dstid" under vilken den inte kan tryckas igen.
Koden definierar en publik deadTime-f�lt som specificerar l�ngden p� d�dstiden i sekunder, och ett privat _deadTimeActive-booleskt f�lt som h�ller reda p� om knappen f�r n�rvarande 
�r i d�dstiden. Den definierar ocks� tv� publika UnityEvent-f�lt, onPressed och onReleased, som kan anv�ndas f�r att specificera �tg�rder som ska vidtas n�r knappen trycks eller sl�pps.
Koden har tv� OnTriggerEnter()- och OnTriggerExit()-funktioner, som kallas n�r ett annat objekt kommer in eller l�mnar triggerns kolliderare som �r ansluten till knappobjektet. 
Dessa funktioner kontrollerar om det objekt som kommer in eller g�r ut har en "Button"-tagg och om d�dstiden f�r n�rvarande �r aktiv. Om b�da dessa villkor �r uppfyllda, anropas onPressed- eller onReleased-h�ndelsen och ett debugmeddelande loggas till konsolen.
N�r OnTriggerExit()-funktionen anropas startar den ocks� en koroutine som heter WaitForDeadTime(), som s�tter _deadTimeActive-f�ltet till true och v�ntar sedan p� den
specificerade deadTime-perioden innan den s�tts tillbaka till false. Detta hindrar knappen fr�n att tryckas igen tills d�dstiden har g�tt.*/




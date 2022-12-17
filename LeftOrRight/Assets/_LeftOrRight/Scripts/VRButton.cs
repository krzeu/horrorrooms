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

using System.Collections;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    
    // IEnumerator : En "interface" / strategi som till�ter oss att utf�ra n�got steg f�r steg
    // yield : Ge v�g f�r, "V�nta p�", Jag tar en pause nu och �terkommer senare

    // yield return : Jag tar en paus nu (yield), (return) h�r �r n�r jag planerar att �terkomma

      
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(DelayedExecution());

        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(RepeatingExecution());

        if (Input.GetKeyDown(KeyCode.Alpha3))
            StartCoroutine(RepeatingExecDuration());

        if (Input.GetKeyDown(KeyCode.Alpha4))
            StartCoroutine(CondtionalExecution());
    }

    IEnumerator DelayedExecution(float delaySeconds = 5f)
    {
        yield return new WaitForSeconds(delaySeconds);

        Debug.Log("Time is up!");
    }

    IEnumerator RepeatingExecution(float intervalSeconds = 1f)
    {
        while (true)
        {
            Debug.Log($"Executing with an interval of {intervalSeconds} seconds");

            yield return new WaitForSeconds(intervalSeconds);
        }
    }

    IEnumerator RepeatingExecDuration(float intervalSeconds = 1f, float durationSeconds = 10f)
    {
        float timeElapsed = 0f;

        while (timeElapsed < durationSeconds)
        {
            Debug.Log($"Executing with an interval of {intervalSeconds} seconds");

            timeElapsed += intervalSeconds;
            yield return new WaitForSeconds(intervalSeconds);
        }

        Debug.Log("Time is up!");
    }


    bool SomeCondition()
    {
        bool result = Input.GetKeyDown(KeyCode.Space);
        return result;
    }

    IEnumerator CondtionalExecution()
    {
        Debug.Log("Time to work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;  // Waits one frame

        Debug.Log("Worker did work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker did more work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker finished the job!");
    }
}

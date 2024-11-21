using UnityEngine;
using System.Collections;

public class Coroutines : MonoBehaviour
{
    // IEnumerator : En "interface"/strategi som till�ter oss att utf�ra n�got steg f�r steg
    // yield : Ge v�g f�r, "V�nta p�", Jag tar en paus h�r och �terkommer senare

    // yield return : Jag tar en pause nu (yield), h�r �r min plan f�r �terkomst (return)


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))  // 1 DelayedExecution
            StartCoroutine(DelayedExecution());
        
        else if (Input.GetKeyDown(KeyCode.Alpha2))  // 2 RepeatingExecution
            StartCoroutine(RepeatingExecution());

        else if (Input.GetKeyDown(KeyCode.Alpha3))  // 3 RepeatingExecDuration
            StartCoroutine(RepeatingExecDuration());

        else if (Input.GetKeyDown(KeyCode.Alpha4))  // 4 ConditionalExecution
            StartCoroutine(ConditionalExecution());
    }

    IEnumerator DelayedExecution(float delaySeconds = 5f)
    {
        yield return new WaitForSeconds(delaySeconds);

        Debug.Log($"{delaySeconds} seconds is up!");
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

        Debug.Log($"{durationSeconds} seconds is up!");
    }

    bool SomeCondition()
    {
        bool result = Input.GetKeyDown(KeyCode.Space);
        return result;
    }

    IEnumerator ConditionalExecution()
    {
        Debug.Log("Time to work!");

        yield return new WaitUntil(SomeCondition);  // Vi kan v�nda p� denna med 'WaitWhile', och v�nta *medan* v�rt condition �r sant
        yield return null;

        Debug.Log("Worker did work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker did more work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker got the job done!");
    }
}

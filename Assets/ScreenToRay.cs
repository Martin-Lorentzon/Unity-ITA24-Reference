using UnityEngine;

public class ScreenToRay : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
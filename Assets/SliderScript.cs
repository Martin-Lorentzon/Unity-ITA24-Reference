using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(slider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeSlider : MonoBehaviour {

    public Slider minSlider;
    public Slider maxSlider;

	// Use this for initialization
	void Start () {

        minSlider.onValueChanged.AddListener(delegate { MinValueChangeCheck(); });
        maxSlider.onValueChanged.AddListener(delegate { MaxValueChangeCheck(); });
    }
    
    public void MinValueChangeCheck()
    {
        if(minSlider.value > maxSlider.value)
        {
            maxSlider.value = minSlider.value;
        }
    }

    public void MaxValueChangeCheck()
    {
        if (minSlider.value > maxSlider.value)
        {
            minSlider.value = maxSlider.value;
        }
    }
}

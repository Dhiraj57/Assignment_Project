using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleMovement : MonoBehaviour
{
    public ToggleGroup group;
    public Toggle low;
    public Toggle medium;
    public Toggle high;
    private static Toggle newToggle;
    public static bool bLow, bHigh, bMedium;

    private void Start()
    {
        // To check previous selection of toggle 
        if(newToggle)
        {
            newToggle.isOn = true;
        }
        else
        {
            low.isOn = true;
        }
    }

    // To get change in toggle values and change the settings accordingly
    public void ValueChange()
    {
        Toggle toggle = group.ActiveToggles().FirstOrDefault() ;

        newToggle = toggle;
        
        if( low == toggle)
        {
            bLow = true;
            bHigh = false;
            bMedium = false;
            low.isOn = true;
        }
        else if (medium == toggle)
        {
            bLow = false;
            bHigh = false;
            bMedium = true;
            medium.isOn = true;
        }
        else if (high == toggle)
        {
            bLow = false;
            bHigh = true;
            bMedium = false;
            high.isOn = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleSpeed : MonoBehaviour
{
    public ToggleGroup group;
    public Toggle low;
    public Toggle medium;
    public Toggle high;
    private static Toggle newToggle;
    public static bool bLowSpeed, bHighSpeed, bMediumSpeed;

    private void Start()
    {
        // To check previous selection of toggle
        if (newToggle)
        {
            newToggle.isOn = true;
        }
        else
        {
            medium.isOn = true;
        }
    }

    // To get change in toggle values and change the settings accordingly
    public void ValueChange()
    {
        Toggle toggle = group.ActiveToggles().FirstOrDefault();

        newToggle = toggle;

        if (low == toggle)
        {
            bLowSpeed = true;
            bHighSpeed = false;
            bMediumSpeed = false;
            low.isOn = true;
        }
        else if (medium == toggle)
        {
            bLowSpeed = false;
            bHighSpeed = false;
            bMediumSpeed = true;
            medium.isOn = true;
        }
        else if (high == toggle)
        {
            bLowSpeed = false;
            bHighSpeed = true;
            bMediumSpeed = false;
            high.isOn = true;
        }
    }
}

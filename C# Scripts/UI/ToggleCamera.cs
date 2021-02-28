using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleCamera : MonoBehaviour
{
    public ToggleGroup group;
    public Toggle primary;
    public Toggle secondary;
    private static Toggle newToggle;
    public static bool bPrimary, bSecondary;

    private void Start()
    {
        // To check previous selection of toggle
        if (newToggle)
        {
            newToggle.isOn = true;
        }
        else
        {
            primary.isOn = true;
        }
    }

    // To get change in toggle values and change the settings accordingly
    public void ValueChange()
    {
        Toggle toggle = group.ActiveToggles().FirstOrDefault();

        newToggle = toggle;

        if (primary == toggle)
        {
            Debug.Log("primary");
            primary.isOn = true;
        }
        else if (secondary == toggle)
        {
            Debug.Log("secondary");
            secondary.isOn = true;
        }
    }
}

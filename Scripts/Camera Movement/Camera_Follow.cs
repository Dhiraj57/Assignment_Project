using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform lookAt ;
    private Vector3 offSet = new Vector3(0, 2.9f, 4);
    private Vector3 startPosition = new Vector3(0, 2.9f, 4);
    private Vector3 followPosition = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // To set the start position of camera
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(15, 180, 0);
        Settings();
    }

    // Update is called once per frame
    void Update()
    {
        // To follow the player
        if(lookAt)
        {
            followPosition = lookAt.transform.position;
            transform.position = followPosition + offSet;
        }

    }

    // To apply the changes made in settings menu
    void Settings()
    {
        if(ToggleCamera.bPrimary)
        {
            offSet.z = 4f;
        }
        else if(ToggleCamera.bSecondary)
        {
            offSet.z = 7f;
        }
    }

}

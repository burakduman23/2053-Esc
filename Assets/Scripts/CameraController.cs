using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera;

    public static bool zoomed1 = false, zoomed2 = false, zoomed3 = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.key2 && !zoomed1) {
            zoomed1 = true;
            Invoke("zoomIn", 0.5f);
            
        }

        if (GameController.key4 && !zoomed2)
        {
            zoomed2 = true;
            Invoke("zoomIn", 0.5f);
        }
        if (GameController.key6 && !zoomed3)
        {
            zoomed3 = true;
            Invoke("zoomIn", 0.5f);
        }
    }

    void zoomIn()
    {
        zoomCamera.enabled = true;
        mainCamera.enabled = false;
        
        Invoke("zoomOut", 1.5f);
    }

    void zoomOut()
    {
        mainCamera.enabled = true;
        zoomCamera.enabled = false;
    }
}

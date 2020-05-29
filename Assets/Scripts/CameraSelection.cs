using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    public GameObject sCam;
    public GameObject fCam;
    public GameObject selectPanel;
    public void staticCam()
    {
        selectPanel.SetActive(false);
        sCam.SetActive(true);
        Time.timeScale = 1f;
    }

    public void followCam()
    {
        Time.timeScale = 1f;
        selectPanel.SetActive(false);
        fCam.SetActive(true);
        

    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

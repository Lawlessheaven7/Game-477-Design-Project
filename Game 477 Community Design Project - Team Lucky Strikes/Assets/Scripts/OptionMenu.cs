using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionMenu : MonoBehaviour
{
    public Toggle fullScreenTog;
    public Toggle vSyncTog;

    public ResolutionItem[] resolutions;

    public TMP_Text resolutionText;

    private int selectedResolution;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vSyncTog.isOn = false;
        }
        else
        {
            vSyncTog.isOn = true;
        }

        //search for resolution in the list
        bool foundResolution = false;

        //loop through all the availbale resolution options to find and set the correct one 
        for(int i = 0; i < resolutions.Length; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundResolution = true;

                selectedResolution = i;

                updateResolutionText();
            }

        }

        if (!foundResolution)
        {
            resolutionText.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedResolution--;
        //Do not go below the element 0
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }

        updateResolutionText();
    }

    public void ResRight()
    {
        selectedResolution++;
        //Do not go above the maximum element
        if (selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length -1;
        }

        updateResolutionText();
    }

    public void updateResolutionText()
    {
        resolutionText.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Apply Full Screen
        //Screen.fullScreen = fullScreenTog.isOn;

        //Apply Vsync
        if (vSyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        //set resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
    }
}

[System.Serializable]
public class ResolutionItem
{
    public int horizontal, vertical;
}

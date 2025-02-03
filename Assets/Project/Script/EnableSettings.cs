using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSettings : MonoBehaviour
{
    public  CameraRotate cameraRot;

    private void OnEnable()
    {
        cameraRot.EnableSettingsPanel();
    }
}

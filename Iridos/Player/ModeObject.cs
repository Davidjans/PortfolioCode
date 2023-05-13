using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ModeObject : MonoBehaviour
{
    [FormerlySerializedAs("vrObject")] public GameObject m_VrObject; // the object to enable in VR mode
    [FormerlySerializedAs("flatScreenObject")] public GameObject m_FlatScreenObject; // the object to enable in flat screen mode

    private void Start()
    {
        // Enable the appropriate object based on the current mode
        if (ModeManager.Instance.currentMode == ModeManager.Mode.VRMode)
        {
            m_VrObject.SetActive(true);
            m_FlatScreenObject.SetActive(false);
        }
        else if (ModeManager.Instance.currentMode == ModeManager.Mode.FlatScreenMode)
        {
            m_VrObject.SetActive(false);
            m_FlatScreenObject.SetActive(true);
        }
    }
}
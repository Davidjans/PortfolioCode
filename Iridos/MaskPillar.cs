using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPillar : MonoBehaviour
{
    public List<GameObject> m_MasksToEnablePerMask;
    public List<GameObject> m_GemToEnablePerMask;
    public GameObject m_WholeMask;
    private void Start()
    {
        foreach (var mask in MaskPieceManager.Instance.m_MaskPiecesGrabbed)
        {
            m_GemToEnablePerMask[mask].SetActive(true);
            m_MasksToEnablePerMask[mask].SetActive(true);
        }
    }

    public void Grabbed(int maskID)
    {
        m_GemToEnablePerMask[maskID].SetActive(true);
        m_MasksToEnablePerMask[maskID].SetActive(true);
        bool failed = false;
        foreach (var VARIABLE in m_MasksToEnablePerMask)
        {
            if (!VARIABLE.activeSelf)
                failed = true;
        }

        if (!failed)
        {
            m_WholeMask.SetActive(true);
        }
    }
}

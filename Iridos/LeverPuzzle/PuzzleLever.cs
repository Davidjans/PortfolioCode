using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLever : MonoBehaviour
{
    public bool m_CurrentState;
    public bool m_StateShouldBe;
    public bool m_IsCorrectState;

    public void Start()
    {
        SetLeverState(m_CurrentState);
    }

    public void SetLeverState(bool newState)
    {
        m_CurrentState = newState;
        if (m_StateShouldBe == m_CurrentState)
            m_IsCorrectState = true;
        else
        {
            m_IsCorrectState = false;
        }
        LeverManager.Instance.CheckLevers();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public bool m_StartValue;
    public bool m_Lighted;
    public List<GameObject> childLamps = new List<GameObject>();

    public void Start()
    {
        Reset();
    }

    public void TurnOn()
    {
        m_Lighted = true;
        foreach (GameObject childLamp in childLamps)
        {
            childLamp.SetActive(true);
        }
    }

    public void TurnOff()
    {
        m_Lighted = false;
        foreach (GameObject childLamp in childLamps)
        {
            childLamp.SetActive(false);
        }
    }
    public void Toggle()
    {
        m_Lighted = !m_Lighted;
        foreach (GameObject childLamp in childLamps)
        {
            childLamp.SetActive(!childLamp.activeSelf);
        }
    }

    public void Reset()
    {
        if (m_StartValue != m_Lighted)
        {
            Toggle();
        }
    }
}

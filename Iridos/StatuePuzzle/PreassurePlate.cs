using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using StackedBeans.Utils;
using UnityEngine;
using UnityEngine.Events;

public class PreassurePlate : MonoBehaviour
{
    public bool m_CanPress = true;
    public int m_PreassurePlateIndex;
    public float m_PressTimer = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (!m_CanPress)
            return;
        if (collision.transform.CompareTag("Player"))
        {
            m_CanPress = false;
            GetComponent<AudioSource>().Play();
            StatueManager.Instance.CheckCorrectOnePressed(m_PreassurePlateIndex);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (!m_CanPress && other.transform.CompareTag("Player"))
        {
            Invoke(nameof(AllowPress),m_PressTimer);
        }
    }

    private void AllowPress()
    {
        m_CanPress = true;
        GetComponent<AudioSource>().time = 0;
    }
}
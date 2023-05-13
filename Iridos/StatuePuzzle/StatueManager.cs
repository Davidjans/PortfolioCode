using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StatueManager : SerializedMonoBehaviour
{
    #region Instancing

    public static StatueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StatueManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("StatueManager").AddComponent<StatueManager>();
                }
            }

            return _instance;
        }
    }

    private static StatueManager _instance;

    private void Awake()
    {
        // Destroy any duplicate instances that may have been created
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    #endregion
    public List<Statue> m_AllStatues;
    public List<int> m_OrderShouldGo;
    public List<List<Statue>> m_StatuesToTurnOnPerIndex;
    public GameObject m_MaskToEnable;
    public AudioClip m_SoundToPlay;
    [HideInEditorMode] public int m_NextToPress;
    [HideInEditorMode] public int m_CurrentIndex;
    public void Start()
    {
        m_NextToPress = m_OrderShouldGo[0];
        m_CurrentIndex = 0;
    }

    public bool CheckCorrectOnePressed(int idPressed)
    {
        if (idPressed != m_NextToPress)
        {
            Reset();
            return false;
        }
        else
        {
            if (m_CurrentIndex >= m_OrderShouldGo.Count -1)
                Finished();
            else
            {
                m_CurrentIndex++;
                m_NextToPress = m_OrderShouldGo[m_CurrentIndex];
                foreach (var statue in m_AllStatues)
                {
                    statue.TurnOff();
                }
                foreach (var statue in m_StatuesToTurnOnPerIndex[m_CurrentIndex])
                {
                    statue.TurnOn();
                }
            }
                
            return true;
        }
    }

    public void Finished()
    {
        Debug.LogError("Puzzle success");
        m_MaskToEnable.SetActive(true);
        AudioSource.PlayClipAtPoint(m_SoundToPlay,transform.position);
    }
    
    public void Reset()
    {
        m_CurrentIndex = 0;
        m_NextToPress = m_OrderShouldGo[0];
        foreach (var statue in m_AllStatues)
        {
            statue.Reset();
        }
    }
}

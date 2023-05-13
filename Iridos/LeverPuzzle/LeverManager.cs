using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class LeverManager : MonoBehaviour
{
    #region Instancing

    public static LeverManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LeverManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("LeverManager").AddComponent<LeverManager>();
                }
            }

            return _instance;
        }
    }

    private static LeverManager _instance;

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

    public GameObject m_MaskToEnable;
    public AudioClip m_SoundToPlay;
    public List<PuzzleLever> m_PuzzleLevers;
    [Button]
    public void CheckLevers()
    {
        var statuesActive = from lever in m_PuzzleLevers where lever.m_IsCorrectState == false select lever;
        if (statuesActive.Any())
        {
            Debug.LogError("Levers not correct");
        }
        else
        {
            m_MaskToEnable.SetActive(true);
            AudioSource.PlayClipAtPoint(m_SoundToPlay,transform.position);
            Debug.LogError("Hooray all levers correct");
        }
    }

}

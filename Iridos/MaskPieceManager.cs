using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPieceManager : MonoBehaviour
{
    
    #region Instancing

    public static MaskPieceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MaskPieceManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("MaskPieceManager").AddComponent<MaskPieceManager>();
                }
            }

            return _instance;
        }
    }

    private static MaskPieceManager _instance;

    private void Awake()
    {
        // Destroy any duplicate instances that may have been created
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }
    #endregion

    public List<int> m_MaskPiecesGrabbed;
    
    
    public void GrabMask(int maskID)
    {
        m_MaskPiecesGrabbed.Add(maskID);
        MaskPillar pillar = FindObjectOfType<MaskPillar>();
        if (pillar != null)
        {
            pillar.Grabbed(maskID);
        }
    }
}

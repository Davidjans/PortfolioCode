using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPiece : MonoBehaviour
{
    public void MaskGrabbed(int maskID)
    {
        MaskPieceManager.Instance.GrabMask(maskID);
    }

    public void DestroyTheFucker()
    {
        Destroy(gameObject);
    }
}

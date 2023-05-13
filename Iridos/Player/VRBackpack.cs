using System.Collections;
using System.Collections.Generic;
using BNG;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class VRBackpack : MonoBehaviour
{
    public List<GameObject> m_ObjectsToEnableDisableWhenGrabbed;
    public List<MonoBehaviour> m_ComponentsToEnbableDisableWhenGrabbed;
    public List<SnapZone> m_InventorySlots;
    public void EnableDisableThings()
    {
        foreach (var gameObjects in m_ObjectsToEnableDisableWhenGrabbed)
        {
            gameObjects.SetActive(!gameObjects.activeSelf);
        }
        foreach (var components in m_ComponentsToEnbableDisableWhenGrabbed)
        {
            components.enabled = !components.enabled;
        }
    }

    public void AddToInventory(Item item)
    {
        foreach (var snapZone in m_InventorySlots)
        {
            if (snapZone.HeldItem == null)
            {
                snapZone.GrabGrabbable(item.GetComponent<Grabbable>());
            }
        }
    }
}

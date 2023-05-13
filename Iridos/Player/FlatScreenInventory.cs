using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatScreenInventory : MonoBehaviour
{
    public GameObject m_InventoryUI;
    public List<Item> m_ItemsInInventory;

    private void Start()
    {
        if(ModeManager.Instance.currentMode == ModeManager.Mode.VRMode)
            Destroy(gameObject);
    }

    public void AddItem(Item itemToAdd)
    {
        if (!m_ItemsInInventory.Contains(itemToAdd))
        {
            m_ItemsInInventory.Add(itemToAdd);
        }
    }

    public Item UseItem(int itemID)
    {
        foreach (var itemInInventory in m_ItemsInInventory)
        {
            if (itemInInventory.m_ItemId == itemID)
            {
                m_ItemsInInventory.Remove(itemInInventory);
                return itemInInventory;
            }
        }
        return null;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            m_InventoryUI.SetActive(!m_InventoryUI.activeSelf);
        }
    }
}

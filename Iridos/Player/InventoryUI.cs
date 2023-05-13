using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryGrid;
    public FlatScreenInventory m_FlatScreenInventory;
    public List<Image> m_SpriteImages;
    private void Start()
    {
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        foreach (var itemSlot in m_SpriteImages)
        {
            itemSlot.gameObject.SetActive(false);
        }
        List<Item> items = m_FlatScreenInventory.m_ItemsInInventory;
        for (int i = 0; i < items.Count; i++)
        {
            m_SpriteImages[i].gameObject.SetActive(true);
            m_SpriteImages[i].sprite = items[i].m_ItemImage;
        }
    }

    private void OnEnable()
    {
        RefreshInventoryItems();
    }
}
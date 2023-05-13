using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
//using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class CraftingManager : SerializedMonoBehaviour
{
    public List<Recipe> m_CraftingList;
    private void Start()
    {
            
    }

    public Item CheckItemCraftable(ItemComponent[,] craftingGrid)
    {
        foreach (Recipe recipe in m_CraftingList)
        {
            bool foundItem = recipe.CheckPlacementCorrect(craftingGrid);
            if (foundItem == true)
                return recipe.m_LinkedItem;
        }
        return null;
    }
}

public enum ItemComponent
{
    Nothing,
    Stick,
    Iron
}
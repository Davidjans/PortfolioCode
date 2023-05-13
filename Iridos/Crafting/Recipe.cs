using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Crafting/Recipe", order = 1)]
public class Recipe : SerializedScriptableObject
{
    [TableMatrix(HorizontalTitle = "X", VerticalTitle = "Y")]
    public ItemComponent[,] m_RecipePlacement = new ItemComponent[3, 3];
    public Item m_LinkedItem;
    
    public bool CheckPlacementCorrect(ItemComponent[,] grid)
    {
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (grid[x, y] != m_RecipePlacement[x, y])
                {
                    return true;
                }
            }
        }
        return false;
    }
}

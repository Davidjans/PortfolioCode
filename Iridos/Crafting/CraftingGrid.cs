using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CraftingGrid : MonoBehaviour
{
    [TableMatrix(HorizontalTitle = "X", VerticalTitle = "Y")]
    public ItemComponent[,] grid = new ItemComponent[3, 3];

    public void ChangeTableSlot(int x, int y, ItemComponent component)
    {
        grid[x, y] = component;
    }
}

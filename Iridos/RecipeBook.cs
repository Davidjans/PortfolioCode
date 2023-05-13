using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public int m_CurrentPage = 0;
    public List<GameObject> m_PageObjects;

    public void NextPage()
    {
        if ( m_CurrentPage == m_PageObjects.Count-1)
        {
            m_CurrentPage = 0;
        }
        else
        {
            m_CurrentPage++;
        }
        
        SwitchPage();
    }

    public void PreviousPage()
    {
        if (m_PageObjects.Count == 0)
        {
            m_CurrentPage = m_PageObjects.Count;
        }
        else
        {
            m_CurrentPage--;
        }
        SwitchPage();
    }

    public void SwitchPage()
    {
        foreach (var page in m_PageObjects)
        {
            page.SetActive(false);
        }
        
        m_PageObjects[m_CurrentPage].SetActive(true);
    }

    public void ToggleRecipeBook()
    {
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
    }
    
    public void Update()
    {
        if (ModeManager.Instance.currentMode == ModeManager.Mode.FlatScreenMode)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                ToggleRecipeBook();
            }
        }
    }
}

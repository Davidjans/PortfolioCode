using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMenu : MonoBehaviour
{
    public void SpawnItem(Item itemToSpawn)
    {
        if (itemToSpawn == null)
            return;
        if (ModeManager.Instance.currentMode == ModeManager.Mode.FlatScreenMode)
        {
            FindObjectOfType<FlatScreenInventory>().AddItem(itemToSpawn);
        }
        else if (ModeManager.Instance.currentMode == ModeManager.Mode.VRMode)
        {
            GameObject item = Instantiate(itemToSpawn.gameObject);
            FindObjectOfType<VRBackpack>(true).AddToInventory(item.GetComponent<Item>());
        }
    }
    
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
        }
    }
}

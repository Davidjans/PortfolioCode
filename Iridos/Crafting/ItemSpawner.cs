using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item m_ItemToSpawn;

    private void Start()
    {
        Instantiate(m_ItemToSpawn,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    
}

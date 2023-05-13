using PhysicsBasedCharacterController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpMaterial : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.enabled = true;
            uiText.text = "'E' " + gameObject.name;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                PickUp();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiText.enabled = false;
        }
    }

    void PickUp()
    {
        uiText.enabled = false;
        Destroy(gameObject);
    }
}

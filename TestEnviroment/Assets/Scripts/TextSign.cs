using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSign : MonoBehaviour, IInteractable
{
    public string message;
    public GameObject indicator;

    public void OnInteract()
    {
        Debug.Log(message);
    }

    public void OnEndInteract()
    {
    }

    public void OnSelect()
    {
        indicator.SetActive(true);
    }

    public void OnDeselect()
    {
        indicator.SetActive(false);
    }
}

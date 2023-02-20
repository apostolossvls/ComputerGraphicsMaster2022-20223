using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnInteract();

    void OnEndInteract();

    void OnSelect();

    void OnDeselect();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    IInteractable currentInteractable;
    Transform currentTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.OnInteract();
        }
    }

    //Once every frame for every collider triggered / every object in area
    private void OnTriggerStay(Collider other)
    {
        //tag comparison
        if (other.CompareTag("Interactable"))
        {
            if (currentTransform == null)
            {
                IInteractable interactable = other.GetComponent<IInteractable>();
                SwitchTarget(interactable, other.transform);
            }
            else if (currentTransform != other.transform)
            {
                float distanceWithCurrent = Vector3.Distance(currentTransform.position, transform.position);
                float distanceWithPotential = Vector3.Distance(other.transform.position, transform.position);
                //float distanceWithPotential = (transform.position - currentTransform.position).sqrMagnitude;

                if (distanceWithPotential < distanceWithCurrent)
                {
                    IInteractable interactable = other.GetComponent<IInteractable>();
                    SwitchTarget(interactable, other.transform);
                }
            }
            //search for an IInteractable
            currentInteractable = other.GetComponent<IInteractable>();

            //Debug.Log(other.name);
        }
    }

    void SwitchTarget(IInteractable newInteraclable, Transform newTransform)
    {
        if (currentInteractable != null) currentInteractable.OnDeselect();

        currentTransform = newTransform;
        currentInteractable = newInteraclable;

        currentInteractable.OnSelect();
    }
}

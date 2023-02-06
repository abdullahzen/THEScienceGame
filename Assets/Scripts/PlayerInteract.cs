using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 7f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractable.Interact();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            float interactRange = 7f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractable.HideInteract();
                }
            }
        }
    }

    public NPCInteractable GetInteractableObject() 
    {
        float interactRange = 7f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                return npcInteractable;
            }
        }
        return null;
    }
}

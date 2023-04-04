using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;
    [SerializeField] private GameObject containerGameObject;

    public void Interact()
    {
        containerGameObject.SetActive(true);
    }

    public void HideInteract()
    {
        containerGameObject.SetActive(false);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}

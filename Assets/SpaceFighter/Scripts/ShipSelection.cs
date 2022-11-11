using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private Animator shipAnimator;
    private int currentShip;

    private void Awake()
    {
        SelectShip(0);
        shipAnimator = GameObject.Find("warhead_LOD2").gameObject.GetComponent<Animator>();
    }

    private void SelectShip(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeShip(int _change)
    {
        currentShip += _change;
        SelectShip(currentShip);
    }

    public void PlayShipAnimation(){
        shipAnimator.enabled = true;
        shipAnimator.Play("ShipLaunchAnim");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atomPrefab : MonoBehaviour
{
    [SerializeField]
    private Button atomButton;
    [SerializeField]
    private submitButton submit;
    private Glow glow;
    private int clickCount;
    void Start()
    {
        Button btn = atomButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        glow = atomButton.GetComponentInChildren<Glow>();
        glow.glowOff();
        clickCount = -1;
    }

    void TaskOnClick()
    {
        clickCount++;
        if (clickCount%2 == 0)
        {
            submit.addOrRemoveAtom(atomButton.name, false);
            glow.glowOn();
        }
        else
        {
            submit.addOrRemoveAtom(atomButton.name, true);
            glow.glowOff();
        }
        
    }
    void Update()
    {
        
    }
}

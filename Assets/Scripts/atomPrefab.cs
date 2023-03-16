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
    [SerializeField]
    public bool isGlowing;
    
    private Glow glow;
    public int clickCount;
    
    
    void Start()
    {

        Button btn = atomButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        if(isGlowing){ 
            glow = atomButton.GetComponentInChildren<Glow>();
            glow.glowOff();
        }
        clickCount = -1;

        

    }

    void TaskOnClick()
    {
        clickCount++;
        if (clickCount%2 == 0)
        {
            gameObject.tag = "Clicked";
            submit.addOrRemoveAtom(atomButton.name + "", false);
            if(isGlowing)
                glow.glowOn();
        }
        else
        {
            gameObject.tag = "Button";
            submit.addOrRemoveAtom(atomButton.name + "", true);
            if(isGlowing) 
                glow.glowOff();
        }
        
    }

    void glowOffPrefab()
    {
        glow.glowOff();
    }
}

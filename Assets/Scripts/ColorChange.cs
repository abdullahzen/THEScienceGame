using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HSVPicker;


public class ColorChange : MonoBehaviour
{
    public Renderer[] renderers;
    public ColorPicker picker;

    public Color Color = Color.red;
    public bool SetColorOnStart = false;

    [SerializeField]
    private Button engineChange;
    [SerializeField]
    private Button wingChange;
    [SerializeField]
    private Button bodyChange;

    private int _i = 0;

    // Use this for initialization
    void Start()
    {
        engineChange.onClick.AddListener(changeToEngine);
        wingChange.onClick.AddListener(changeToWing);
        bodyChange.onClick.AddListener(changeToBody);

        picker.onValueChanged.AddListener(color =>
        {
            renderers[_i].material.color = color;
            Color = color;
        });

        renderers[_i].material.color = picker.CurrentColor;
        if (SetColorOnStart)
        {
            picker.CurrentColor = Color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeToEngine()
    {
        _i = 0;
    }

    public void changeToWing()
    {
        _i = 2;
    }

    public void changeToBody()
    {
        _i = 1;
    }
}

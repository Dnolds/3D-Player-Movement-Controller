using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
    public AxisButtons[] axisKeys;
    public KeyCode[] buttonKeys;
    // Update is called once per frame
    private void Reset()
    {
        im = GetComponent<InputManager>();
        axisKeys = new AxisButtons[im.axisCount];
        buttonKeys = new KeyCode[im.buttonCount];
    }
    void Update()
    {
        //Check for inputs, if inputs detected, set newData to true;
        //populate InputData to pass to the InputManager
        for (int i = 0; i < axisKeys.Length; i++)
        {
            float val = 0;
            if (Input.GetKey(axisKeys[i].positive))
            {
                val += 1;
                newData = true;
            }
            if (Input.GetKey(axisKeys[i].negative))
            {
                val -= 1;
                newData = true;
            }
            data.axes[i] = val;
        }
        for (int i = 0; i < buttonKeys.Length; i++)
        {
            if (Input.GetKey(buttonKeys[i]))
            {
                data.buttons[i] = true;
                newData = true;
            }
        }
        if (newData)
        {
            im.PassInput(data);
            newData = false;
            data.Reset();
        }
    }
    public override void Refresh()
    {
        im = GetComponent<InputManager>();

        //create 2 temp array for buttons and axes
        KeyCode[] newButtons = new KeyCode[im.buttonCount];
        AxisButtons[] newAxes = new AxisButtons[im.axisCount];

        if(buttonKeys != null)
        {
            for(int i = 0; i < Mathf.Min(newButtons.Length, buttonKeys.Length); i++)
            {
                newButtons[i] = buttonKeys[i];
            }
        }
        buttonKeys = newButtons;
        if (axisKeys != null)
        {
            for (int i = 0; i < Mathf.Min(newAxes.Length, axisKeys.Length); i++)
            {
                newAxes[i] = axisKeys[i];
            }
        }
        axisKeys = newAxes;
    }
}

[System.Serializable]
public struct AxisButtons
{
    public KeyCode positive;
    public KeyCode negative;
}

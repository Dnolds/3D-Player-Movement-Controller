using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputManagerEditor : Editor
{
    [CustomEditor(typeof(InputManager))]
    public override void OnInspectorGUI()
    {
        //InputManager im = target as InputManager;

        //EditorGUI.BeginChangeCheck();
        
        //base.OnInspectorGUI();
        
        //if (EditorGUI.EndChangeCheck())
        //{
        //    //Call Refresh from DeviceTracker
        //    im.RefreshTracker();
        //}
    }
}

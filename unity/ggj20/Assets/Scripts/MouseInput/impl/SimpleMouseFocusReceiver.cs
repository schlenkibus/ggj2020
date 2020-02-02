using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMouseFocusReceiver : MonoBehaviour, MouseFocusReceiver
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void onMouseFocusGained()
    {
        Debug.Log("Gained: " + gameObject.name);
    }

    public void onMouseFocusLost()
    {
        Debug.Log("Lost: " + gameObject.name);
    }

    public void onClick()
    {
        Debug.Log("Clicked: " + gameObject.name);
    }

    public void onDrag(Vector3 newMousePos, bool s)
    {
        Debug.Log("Drag: " + newMousePos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    GameObject m_mouseOver = null;
    
    void Start()
    {
    }

    void Update()
    {
        bool found = false;
        bool hadPrevious = m_mouseOver != null;
        bool focusOnNewObject = false;
        GameObject oldObject = m_mouseOver;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200.0f))
        {
            MouseFocusReceiver receiver = hit.collider.gameObject.GetComponent<MouseFocusReceiver>();
            if (receiver != null)
            {
                found = true;
                GameObject selection = hit.collider.gameObject;
                
                focusOnNewObject = selection != oldObject;

                if(focusOnNewObject)
                {
                    m_mouseOver = selection;
                }
            }
        }


        if(hadPrevious && (focusOnNewObject || !found)) {
            MouseFocusReceiver receiver = oldObject.GetComponent<MouseFocusReceiver>();
            if(receiver != null) {
                receiver.onMouseFocusLost();
            }
        }

        if(found && focusOnNewObject) {
            MouseFocusReceiver receiver = m_mouseOver.GetComponent<MouseFocusReceiver>();
            if(receiver != null) {
                receiver.onMouseFocusGained();
            }
        } 
        
        if(!found) {
            m_mouseOver = null;
        }


    }
}

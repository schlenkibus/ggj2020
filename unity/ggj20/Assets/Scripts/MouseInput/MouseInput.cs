using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    GameObject m_mouseOver = null;
    
    void Start()
    {
    }

    bool m_leftWasDown = false;

    void Update()
    {
        bool isLeftClickDown = Input.GetMouseButton(0);
        bool stillInDrag = m_leftWasDown && isLeftClickDown && m_mouseOver != null;
        bool hadPrevious = m_mouseOver != null;
        bool found = false;
        bool focusOnNewObject = false;
        GameObject oldObject = m_mouseOver;

        if(!stillInDrag) {
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
        }

        bool inDrag = isLeftClickDown && m_mouseOver;

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
        
        if(m_mouseOver) {

            if(Input.GetMouseButtonDown(0))
            {
                MouseFocusReceiver receiver = m_mouseOver.GetComponent<MouseFocusReceiver>();
                if(receiver != null) {
                    receiver.onClick();
                }
            }

            if(isLeftClickDown)
            {
                Vector3 directionTowardsCamera = DirectionTo(m_mouseOver.transform.position, Camera.main.transform.position);
                Plane plane = new Plane(directionTowardsCamera, m_mouseOver.transform.position);

                float dist;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out dist))
                {
                    Vector3 point = ray.GetPoint(dist);
                    MouseFocusReceiver receiver = m_mouseOver.GetComponent<MouseFocusReceiver>();
                    if(receiver != null) {
                        receiver.onDrag(point);
                    }
                }
            }
        }

        if(!found && !inDrag) {
            m_mouseOver = null;
        }

        m_leftWasDown = isLeftClickDown;
    }

    private Vector3 DirectionTo(Vector3 from, Vector3 to) {
        Vector3 ret = to - from;
        return ret.normalized;
    }
}

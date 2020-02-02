using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    MouseFocusReceiver m_dragReceiver = null;
    GameObject m_draggedObjectObj = null;
    
    void Start()
    {
    }

    bool m_leftWasDown = false; 

    void Update()
    {
        bool isLeftClickDown = Input.GetMouseButton(0);

        if(m_dragReceiver == null) {
            if(isLeftClickDown) {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200.0f))
                {
                    if(hit.collider.gameObject != null) {
                        m_dragReceiver = hit.collider.gameObject.GetComponent<MouseFocusReceiver>();
                        if(m_dragReceiver != null)
                        {    
                            m_dragReceiver.onDragStart();
                            m_draggedObjectObj = hit.collider.gameObject;
                        }
                    }
                }
            }
        }
        
        if(m_dragReceiver != null && isLeftClickDown)
        {
            Vector3 directionTowardsCamera = DirectionTo(m_draggedObjectObj.transform.position, Camera.main.transform.position);
            Plane plane = new Plane(directionTowardsCamera, m_draggedObjectObj.transform.position);

            float dist;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out dist))
            {
                Vector3 point = ray.GetPoint(dist);
                m_dragReceiver.onDrag(point);
            }
        }
        else if(m_dragReceiver != null && !isLeftClickDown)
        {
            m_dragReceiver.onDragEnd();
            m_draggedObjectObj = null;
            m_dragReceiver = null;
        }

        m_leftWasDown = isLeftClickDown;
    }

    private Vector3 DirectionTo(Vector3 from, Vector3 to) {
        Vector3 ret = to - from;
        return ret.normalized;
    }
}

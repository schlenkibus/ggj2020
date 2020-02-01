using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMouseReciever : MonoBehaviour, MouseFocusReceiver
{

    Wander m_wanderScript;
    void Start()
    {
        m_wanderScript = GetComponent<Wander>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMouseFocusGained()
    {
        m_wanderScript.setEnabled(false);
    }

    public void onMouseFocusLost()
    {
        m_wanderScript.setEnabled(true);
    }

    public void onClick()
    {

    }

    public void onDrag(Vector3 newMousePos)
    {
        m_wanderScript.setEnabled(false);
        transform.position = newMousePos;
    }
}

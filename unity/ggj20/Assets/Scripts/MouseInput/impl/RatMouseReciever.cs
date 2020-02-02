using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMouseReciever : MonoBehaviour, MouseFocusReceiver
{

    Wander m_wanderScript;
    GameObject m_currentIsland;

    Animator m_animator;
    AudioSource m_dragSound;

    void Start()
    {
        m_dragSound = GetComponent<AudioSource>();
        m_wanderScript = GetComponent<Wander>();
        m_animator = GetComponentInChildren<Animator>();
        updateIslandRelationship();
    }

    GameObject getClosestIsland() {
        GameObject ret = null;
        float minDist = 9999999f;
        GameObject[] islands = GameObject.FindGameObjectsWithTag("Floor"); 
        foreach (GameObject island in islands)
        {
            float currentDistance = Vector3.Distance(island.transform.position, transform.position);
            if(currentDistance < minDist) {
                minDist = currentDistance;
                ret = island;
            }
        }
        return ret;
    }

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
        m_animator.SetBool("inDrag", false);
        updateIslandRelationship();
    }

    private void updateIslandRelationship() {
        var oldIsland = m_currentIsland;
        m_currentIsland = getClosestIsland();
        if(oldIsland != m_currentIsland) {

            if(m_currentIsland)
                m_currentIsland.GetComponent<IslandController>().onEntityJoinedIsland(gameObject);

            if(oldIsland)
                oldIsland.GetComponent<IslandController>().onEntityLeftIsland(gameObject);
        }
    }

    public void onClick()
    {

    }

    public void onDrag(Vector3 newMousePos, bool isDragStart)
    {
        if(isDragStart) {   
            if(!m_dragSound.isPlaying)
                m_dragSound.Play();
        }
     
        m_animator.SetBool("inDrag", true);
        m_wanderScript.setEnabled(false);
        transform.position = newMousePos;
    }
}

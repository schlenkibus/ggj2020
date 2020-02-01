using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{

    HashSet<GameObject> m_currentIslandEntitys;

    // Start is called before the first frame update
    void Start()
    {
        m_currentIslandEntitys = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEntityJoinedIsland(GameObject entity)
    {
        m_currentIslandEntitys.Add(entity);
        Debug.Log("Joined: " + m_currentIslandEntitys.Count);
    }

    public void onEntityLeftIsland(GameObject entity)
    {
        m_currentIslandEntitys.Remove(entity);
        Debug.Log("Left: " + m_currentIslandEntitys.Count);
    }
}

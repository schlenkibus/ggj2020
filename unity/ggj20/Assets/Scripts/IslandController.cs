using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    HashSet<GameObject> m_currentIslandEntitys;

    void Start()
    {
        m_currentIslandEntitys = new HashSet<GameObject>();
    }

    void Update()
    {
        
    }

    public void onEntityJoinedIsland(GameObject entity)
    {
        m_currentIslandEntitys.Add(entity);
    }

    public void onEntityLeftIsland(GameObject entity)
    {
        m_currentIslandEntitys.Remove(entity);
    }
}

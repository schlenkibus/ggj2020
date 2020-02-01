using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    HashSet<GameObject> m_currentIslandEntitys;
    public Goal m_goal;

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

    public Goal GetGoal() {
        return m_goal;
    }

    public List<Metric> collectMetrics() 
    {
        List<Metric> ret = new List<Metric>();
        foreach(GameObject obj in m_currentIslandEntitys) {
            var metric = obj.GetComponent<Metric>();
            ret.Add(metric);
        }
        return ret;
    }
}

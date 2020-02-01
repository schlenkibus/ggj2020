﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    HashSet<GameObject> m_currentIslandEntitys;
    public Goal m_goal;

    GameManager m_manager;

    void Start()
    {
        m_goal = new Goal();
        m_currentIslandEntitys = new HashSet<GameObject>();
    }

    public void setGameManager(GameManager mng) {
        m_manager = mng;
    }

    void Update()
    {
        
    }

    public void onEntityJoinedIsland(GameObject entity)
    {
        m_currentIslandEntitys.Add(entity);
        entity.transform.SetParent(transform);
        evaluate();
    }

    public void onEntityLeftIsland(GameObject entity)
    {
        m_currentIslandEntitys.Remove(entity);
        evaluate();
    }

    private void evaluate() {
        var metrics = collectMetrics();
        var factors = m_goal.calculatePercentage(metrics);
        Debug.Log(factors);
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

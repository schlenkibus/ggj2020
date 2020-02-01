using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IslandController island1;
    public IslandController island2;
    void Start()
    {
        createGoals();
        island1.setGameManager(this);
        island2.setGameManager(this);
    }

    void Update()
    {
        
    }

    void createGoals() {
        setupWorld1();
        setupWorld2();
    }

    void setupWorld1() {
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();
        
        goals.Add(new Metric(MetricType.Rat, 8));
        goals.Add(new Metric(MetricType.Fox, 3));
        
        factors.Add(MetricType.Rat, 0.5f);
        factors.Add(MetricType.Fox, 0.5f);
        
        island1.m_goal = new Goal(goals, factors);
    }

    void setupWorld2() {
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();

        goals.Add(new Metric(MetricType.Rat, 2));
        goals.Add(new Metric(MetricType.Fox, 7));
        
        factors.Add(MetricType.Rat, 0.5f);
        factors.Add(MetricType.Fox, 0.5f);
        
        island2.m_goal = new Goal(goals, factors);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IslandController summerIsland;
    public IslandController winterIsland;
    void Start()
    {
        createGoals();
        summerIsland.setGameManager(this);
        winterIsland.setGameManager(this);
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
        
        goals.Add(new Metric(MetricType.Rat, 10));
        goals.Add(new Metric(MetricType.Fox, 2));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 1f);
        
        summerIsland.m_goal = new Goal(goals, factors);
    }

    void setupWorld2() {
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();

        goals.Add(new Metric(MetricType.Rat, 10));
        goals.Add(new Metric(MetricType.Fox, 10));
        
        factors.Add(MetricType.Rat, 1);
        factors.Add(MetricType.Fox, 1);
        
        winterIsland.m_goal = new Goal(goals, factors);
    }
}

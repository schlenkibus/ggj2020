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
        
        goals.Add(new Metric(MetricType.Rat, 8));
        goals.Add(new Metric(MetricType.Fox, 3));
        goals.Add(new Metric(MetricType.Penguin, 1));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 1f);
        factors.Add(MetricType.Penguin, 1f);
        
        summerIsland.m_goal = new Goal(goals, factors);
    }

    void setupWorld2() {
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();

        goals.Add(new Metric(MetricType.Rat, 2));
        goals.Add(new Metric(MetricType.Fox, 7));
        goals.Add(new Metric(MetricType.Penguin, 9));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 1f);
        factors.Add(MetricType.Penguin, 1f);
        
        winterIsland.m_goal = new Goal(goals, factors);
    }
}

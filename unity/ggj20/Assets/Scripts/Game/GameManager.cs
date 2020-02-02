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

        //summer
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();
        
        goals.Add(new Metric(MetricType.Rat, 9));
        goals.Add(new Metric(MetricType.Fox, 3));
        goals.Add(new Metric(MetricType.Penguin, 1));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 0.4f);
        factors.Add(MetricType.Penguin, 0.1f);
        
        summerIsland.m_goal = new Goal(goals, factors);
    }

    void setupWorld2() {

        //winter
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();

        goals.Add(new Metric(MetricType.Rat, 1));
        goals.Add(new Metric(MetricType.Fox, 5));
        goals.Add(new Metric(MetricType.Penguin, 8));
        
        factors.Add(MetricType.Rat, 0.2f);
        factors.Add(MetricType.Fox, 0.5f);
        factors.Add(MetricType.Penguin, 0.3f);
        
        winterIsland.m_goal = new Goal(goals, factors);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public IslandController summerIsland;
    public IslandController winterIsland;

    public int FoxSummerCount = 5;
    public int RatSummerCount = 9;
    public int PenguinSummerCount = 2;

    public int FoxWinterCount = 6;
    public int RatWinterCount = 2;
    public int PenguinWinterCount = 12;

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
        
        goals.Add(new Metric(MetricType.Rat, RatSummerCount));
        goals.Add(new Metric(MetricType.Fox, FoxSummerCount));
        goals.Add(new Metric(MetricType.Penguin, PenguinSummerCount));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 1f);
        factors.Add(MetricType.Penguin, 1f);
        
        summerIsland.m_goal = new Goal(goals, factors);
    }

    void setupWorld2() {

        //winter
        Dictionary<MetricType, float> factors = new Dictionary<MetricType, float>();
        List<Metric> goals = new List<Metric>();

        goals.Add(new Metric(MetricType.Rat, RatWinterCount));
        goals.Add(new Metric(MetricType.Fox, FoxWinterCount));
        goals.Add(new Metric(MetricType.Penguin, PenguinWinterCount));
        
        factors.Add(MetricType.Rat, 1f);
        factors.Add(MetricType.Fox, 1f);
        factors.Add(MetricType.Penguin, 1f);
        
        winterIsland.m_goal = new Goal(goals, factors);
    }
}

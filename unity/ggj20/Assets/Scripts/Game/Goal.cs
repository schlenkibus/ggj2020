using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    List<Metric> m_goals;
    // Start is called before the first frame update

    public Goal(List<Metric> goals) {
        m_goals = goals;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool meetsGoals(List<Metric> metrics) {

        Dictionary<MetricType, int> currentValues = new Dictionary<MetricType, int>();        
        
        foreach(Metric metric in metrics) {
            currentValues[metric.getMetricType()] += metric.getMetricValue();
        }

        foreach(Metric goal in m_goals) {
            var current = currentValues[goal.getMetricType()];
            if(current < goal.getMetricValue())
                return false;
        }

        return true;
    }
}

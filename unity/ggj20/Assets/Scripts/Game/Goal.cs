using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public List<Metric> m_goals;
    private Dictionary<MetricType, float> m_typeFactors;

    public Goal() {
        m_goals = new List<Metric>();
    }

    public Goal(List<Metric> goals, Dictionary<MetricType, float> factors) {
        m_goals = goals;
        m_typeFactors = factors;
    }

    void Start() {

    }

    void Update() {

    }

    public float calculatePercentage(List<Metric> metrics) {
        Dictionary<MetricType, int> totalCount = new Dictionary<MetricType, int>();        
        
        foreach(Metric metric in metrics) {
            var type = metric.getMetricType();
            var value = metric.getMetricValue();

            if(totalCount.ContainsKey(type))
                totalCount[type] += value;
            else
                totalCount.Add(type, value);
        }

        float totalPercentage = 0;

        foreach(Metric goal in m_goals) {
            var type = goal.getMetricType();
            float factor = 0;
            
            if(m_typeFactors.ContainsKey(type))
            {
                factor = m_typeFactors[type];
            }

            if(totalCount.ContainsKey(type)) {
                var totalEnitys = totalCount[type];
                if(goal.getMetricValue() != 0) {
                    var percentage = totalEnitys * factor / goal.getMetricValue();
                    totalPercentage += percentage;
                }
            }
        }

        Debug.Log("totalPercentage: " + totalPercentage + " m_goals.Count: " + m_goals.Count);

        if(totalPercentage >= 1.0f * m_goals.Count)
            totalPercentage = 1.0f * m_goals.Count;

        return totalPercentage / m_goals.Count;
    }

    public bool meetsGoals(List<Metric> metrics) {

        Dictionary<MetricType, int> currentValues = new Dictionary<MetricType, int>();        
        
        foreach(Metric metric in metrics) {
            if(currentValues.ContainsKey(metric.getMetricType()))
                currentValues[metric.getMetricType()] += metric.getMetricValue();
            else
                currentValues.Add(metric.getMetricType(), metric.getMetricValue());
        }

        foreach(Metric goal in m_goals) {
            if(currentValues.ContainsKey(goal.getMetricType())) {
                var current = currentValues[goal.getMetricType()];
                if(current < goal.getMetricValue())
                    return false;
            }
        }

        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MetricType {
    Rat
};
public class Metric : MonoBehaviour
{

    public MetricType m_type;
    public int m_value;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public MetricType getMetricType()
    {
        return m_type;
    }

    public int getMetricValue()
    {
        return m_value;
    }
}

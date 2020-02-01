using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MetricType {
    Rat,
    Fox
};

public class Metric : MonoBehaviour
{

    public MetricType m_type;
    public int m_value;

    public Metric(MetricType type, int val) {
        m_type = type;
        m_value = val;
    }

    public Metric() {

    }

    void Update() {

    }

    void Start() {

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

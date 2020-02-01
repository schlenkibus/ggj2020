using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    public GameObject m_prefab;
    public int m_count;

    void Start()
    {
        for(var i = 0; i < m_count; i++) {
            Vector3 pos = transform.position;
            pos.x += i * 5;
            Instantiate(m_prefab, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}

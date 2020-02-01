using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    public GameObject m_prefab;
    public int m_count;

    void Start()
    {
        StartCoroutine(SpawnEntity());
    }

    Vector3 getRandomPositionInRange(Vector3 pos, float distance) 
    {
        float x = Random.Range(pos.x - distance, pos.x + distance);
        float z = Random.Range(pos.z - distance, pos.z + distance);
        pos.x = x;
        pos.z = z;
        return pos;
    }

    IEnumerator SpawnEntity ()
	{
		while (m_count > 0) {
            Instantiate(m_prefab, getRandomPositionInRange(transform.position, 2), Quaternion.identity);    
            m_count--;
            yield return new WaitForSeconds(0.5f);
		}
	} 

    void Update()
    {
        
    }
}

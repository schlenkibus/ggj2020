using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderResetter : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Wander w = other.gameObject.GetComponent<Wander>();
        if(w != null) {
            Debug.Log("Reset Wanderer!");
            w.resetPosition();
        } 
    }
}

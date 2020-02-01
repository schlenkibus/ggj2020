using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyMouseFocusReceiver : MonoBehaviour, MouseFocusReceiver
{

    public Material m_activeMaterial;
    [HideInInspector] private Material m_oldMaterial;

    void Start()
    {
        m_oldMaterial = GetRenderer().material;
    }

    void Update()
    {
    }

    public void onMouseFocusGained()
    {
        setState(true);
    }

    public void onMouseFocusLost()
    {
        setState(false);
    }

    private void setState(bool state)
    {
        Renderer renderer = GetRenderer();
        if(renderer) {
            if(state)
                renderer.material = m_activeMaterial;
            else
                renderer.material = m_oldMaterial;
        }
    }    

    private Renderer GetRenderer() {
        return GetComponent<Renderer>();
    }
}

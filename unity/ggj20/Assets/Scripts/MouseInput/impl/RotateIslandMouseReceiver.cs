using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIslandMouseReceiver : MonoBehaviour, MouseFocusReceiver
{
    public int m_rotationDirection = 0;
    public GameObject m_targetIsland = null;
    public Material m_highlightMaterial;
    [HideInInspector] private Material m_oldMaterial;

    private Renderer m_renderer;
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        m_oldMaterial = m_renderer.material;
    }

    void Update()
    {
        
    }

    public void onClick() {
        m_targetIsland.transform.RotateAround(m_targetIsland.transform.position, m_targetIsland.transform.up, m_rotationDirection);
    }

    public void onDrag(Vector3 newMousePos, bool s) {

    }

    public void onMouseFocusGained() {
        m_renderer.material = m_highlightMaterial;
    }

    public void onMouseFocusLost() {
        m_renderer.material = m_oldMaterial;
    }
}

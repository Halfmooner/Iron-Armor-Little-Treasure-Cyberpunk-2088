using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Renderer m_renderer;
    public Camera m_camera;

    private Vector3 screenPos;
    private bool onScreen;
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        m_camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        CheckVisibility();
    }
    public void CheckVisibility()
    {
        screenPos = m_camera.WorldToScreenPoint(transform.position);
        onScreen = screenPos.x > 0f && screenPos.x < Screen.width && screenPos.y > 0f && screenPos.y < Screen.height;

        if (onScreen && m_renderer.isVisible)
        {
            Debug.Log("Visible");
        }
        else
        {
            Debug.Log("Not Visible");
           
        }
    }
}

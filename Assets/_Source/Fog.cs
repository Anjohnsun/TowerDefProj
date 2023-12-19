using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fogOverTheRoad;
    [SerializeField] private List<GameObject> _fogOverTheTowers;

    [SerializeField] private bool _roadIsVisible;
    [SerializeField] private LayerMask _fogMask;

    private void Start()
    {
        SetGroupVisibility(_fogOverTheRoad, _roadIsVisible);
        SetGroupVisibility(_fogOverTheTowers, !_roadIsVisible);
    }

    private void SetGroupVisibility(List<GameObject> objects, bool value)
    {
        foreach(var v in objects)
        {
            v.SetActive(value);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.05f, _fogMask))
            {
                ChangeFogs();
            }
        }
    }

    private void ChangeFogs()
    {
        Debug.Log("clicked");
        _roadIsVisible = !_roadIsVisible;
        SetGroupVisibility(_fogOverTheRoad, _roadIsVisible);
        SetGroupVisibility(_fogOverTheTowers, !_roadIsVisible);
    }
}

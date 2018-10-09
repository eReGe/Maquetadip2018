﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(LineRenderer))]
public class PathRender : MonoBehaviour
{
    private Transform startMarker, endMarker;
    public Transform[] waypoint;
    public float speed = 20f;
    private float startTime = 0f;
    private float journeyLength = 1f;
    private int currentStartPoint = 0;
    private LineRenderer lineRenderer;
    void Start()
    {
        currentStartPoint = 0;
        SetPoints();
        lineRenderer = GetComponent<LineRenderer>();
    }
    void SetPoints()
    {
        startMarker = waypoint[currentStartPoint];
        endMarker = waypoint[currentStartPoint + 1];
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        Vector3 startPosition = startMarker.position;
        Vector3 endPosition = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
        if (fracJourney >= 1f)
        {
            if (currentStartPoint + 2 < waypoint.Length)
            {
                currentStartPoint++;
                SetPoints();
            }
            else
            {
                //if finished, disable lineRenderer and this script
                lineRenderer.enabled = false;
                this.enabled = false;
            }
        }
    }
}

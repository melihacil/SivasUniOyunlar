using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer m_lineRenderer;
    //aaa
    [SerializeField, Min(3)]
    private int m_lineCount = 60;

    [SerializeField, Min(1)]
    private float m_timeOfTheFlight = 5f;


    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }


    public void ShowTrajectoryLine(Vector3 startPoint, Vector3 startVelocity)
    {

        // Smoothness of the trajectory line 
        float timeStep = m_timeOfTheFlight / m_lineCount;

        Vector3[] lineRendererPoints = CalculateTrajectoryLine(startPoint,startVelocity, timeStep);

        m_lineRenderer.positionCount = m_lineCount;
        m_lineRenderer.SetPositions(lineRendererPoints);

    }

    private Vector3[] CalculateTrajectoryLine(Vector3 startPoint, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[m_lineCount];
        lineRendererPoints[0] = startPoint;

        for (int i = 1; i < m_lineCount; i++)
        {
            float timeOffSet = timeStep * i;

            Vector3 progressBeforeGravity = startVelocity * timeOffSet;
            Vector3 gravityOffSet = Vector3.up * -0.5f * Physics.gravity.y * Mathf.Pow(timeOffSet, 2f);
            Vector3 newPosition = startPoint + progressBeforeGravity - gravityOffSet;
            lineRendererPoints[i] = newPosition;
        
        }


        return lineRendererPoints;
    }




}

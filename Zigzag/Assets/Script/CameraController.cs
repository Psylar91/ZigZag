using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;            
    private const float smoothing = 5f; 
    private Vector3 offset;             

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position;

        float average = (targetPosition.x + targetPosition.z) / 2f;
        Vector3 nextCameraPosition = new Vector3(average, targetPosition.y, average);

        Vector3 targetCamPos = nextCameraPosition + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
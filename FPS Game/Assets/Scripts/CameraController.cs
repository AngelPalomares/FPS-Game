using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform Target;

    private float StartFOV, TargetFOV;

    public float ZoomSpeed = 1f;

    public Camera theCam;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartFOV = theCam.fieldOfView;
        TargetFOV = StartFOV;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Target.rotation;

        theCam.fieldOfView = Mathf.Lerp(theCam.fieldOfView, TargetFOV, ZoomSpeed * Time.deltaTime);
    }

    public void ZoomIn(float newZoom)
    {
        TargetFOV = newZoom;
    }

    public void ZoomOut()
    {
        TargetFOV = StartFOV;
    }
}

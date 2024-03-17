using UnityEngine;

public class CameraControlMask : MonoBehaviour
{
    Camera mainCam;
    public LayerMask renderLayer;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (mainCam.cullingMask != renderLayer)
            mainCam.cullingMask = renderLayer;
    }
}

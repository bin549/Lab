using UnityEngine;
using Cinemachine;

public class LimitYAxis : MonoBehaviour {
    public CinemachineFreeLook freeLookCam;
    public float yAxisLimit = 3f;

    private void Update() {
        var axisControl = freeLookCam.m_YAxis;
        if (axisControl.Value > yAxisLimit) {
            axisControl.Value = yAxisLimit;
        }
    }
}
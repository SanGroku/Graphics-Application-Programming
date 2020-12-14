using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField, Range(0.0f, 360f)]
    private float _angle = 90.0f;

    [SerializeField, Range(0.0f, 8.0f)]
    private float _speed = 2.0f;

    [SerializeField, Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;

    Quaternion _start, _end;

    // Start is called before the first frame update
    private void Start()
    {
        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void AdjustSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    public void AdjustAngle(float newAngle)
    {
        _angle = newAngle;
    }

    private void FixedUpdate()
    {
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    void ResetTimer()
    {
        _startTime = 0.0f;
    }

    Quaternion PendulumRotation(float angle)
    {
        var pendulumRotaiton = transform.rotation;
        var angleZ = pendulumRotaiton.eulerAngles.z + angle;

        if (angleZ > 180)
        {
            angleZ -= 360;
        }
        else if (angleZ < -180)
        {
            angleZ += 360; 
        }

        pendulumRotaiton.eulerAngles = new Vector3(pendulumRotaiton.eulerAngles.x, pendulumRotaiton.eulerAngles.y, angleZ);
        return pendulumRotaiton;
    }
}

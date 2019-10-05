
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;
    private  Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            offset = Quaternion.AngleAxis(2, Vector3.up) * offset;
            transform.position = target.position - offset;
            transform.LookAt(target.position);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            offset = Quaternion.AngleAxis(-2, Vector3.up) * offset;
            transform.position = target.position - offset;
            transform.LookAt(target.position);
        }

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position - offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

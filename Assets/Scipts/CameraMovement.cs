
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.RotateAround(target.position, Vector3.up, 10 * Time.deltaTime);
        }
        
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position - offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

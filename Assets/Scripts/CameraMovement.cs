
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;
    private  Vector3 offset;

    void Start()
    {
        //offset = target.position - transform.position;
        offset = new Vector3(-9.5f, -21.8f, 10.1f);
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

    void LateUpdate()
    {
        Vector3 finaltarget = target.position;
        finaltarget.y = 0.0f;

        Vector3 desiredPosition = finaltarget - offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}

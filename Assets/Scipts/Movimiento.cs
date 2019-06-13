using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point);

                agent.SetDestination(hit.point);
                Debug.Log("MOVEMENT");
            }
        }
    }
}

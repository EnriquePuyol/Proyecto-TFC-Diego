using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera cam;

    private int vida = 8;

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
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coche")
        {
            vida -= other.gameObject.GetComponent<Coche>().Dano;
            Debug.Log("vida restante: " + vida);
        }
    }
}

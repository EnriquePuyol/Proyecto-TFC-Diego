using UnityEngine;
using UnityEngine.AI;

public class Animaciones : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator anim;

    private float vel = 0f;

    // Update is called once per frame
    void Update()
    {
        vel = agent.velocity.magnitude / agent.speed;

        if (vel == 0)
        {
            anim.SetInteger("State", 0);
        }
        else if (vel > 0.3f)
        {
            anim.SetInteger("State", 2);
        }
        else 
        {
            anim.SetInteger("State", 1);
        }
    }

}

﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    NavMeshAgent agent;
    public Camera cam;

    private int vida = 8;

    public Image Corazon1, Corazon2, Corazon3, Corazon4;

    public bool vivo = true;
    private bool pausado = false;

    public Animator pausaAnim;
    public Image pausaFondo;

    public Image pantallaDePerder;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausado == false)
            {
                pausaAnim.SetTrigger("Pausa");
                pausaFondo.gameObject.SetActive(true);
                pausado = true;
                Time.timeScale = 0;
            }
            else
            {
                pausaAnim.SetTrigger("Continuar");
                pausaFondo.gameObject.SetActive(false);
                pausado = false;
                Time.timeScale = 1;
            }
           
        }

        if(Input.GetMouseButtonDown(1) && vivo == true && pausado == false)
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
        if(other.tag == "Victoria")
        {
            vivo = false;
            pantallaDePerder.gameObject.SetActive(true);
            pantallaDePerder.GetComponentInChildren<Text>().text = "¡Has ganado!";
            agent.SetDestination(transform.position);
        }

        if (other.tag == "Coche")
        {
            vida -= other.gameObject.GetComponent<Coche>().Dano;
            Debug.Log("vida restante: " + vida);
        }

        if (vida < 8)
        {
            Corazon4.gameObject.SetActive(false);
        }

        if (vida < 6)
        {
            Corazon3.gameObject.SetActive(false);
        }
        if (vida < 4)
        {
            Corazon2.gameObject.SetActive(false);
        }
        if (vida < 2)
        {
            Corazon1.gameObject.SetActive(false);
        }

        if(vida <= 0)
        {
            vivo = false;
            pantallaDePerder.gameObject.SetActive(true);
            agent.SetDestination(transform.position);
        }
    }


}
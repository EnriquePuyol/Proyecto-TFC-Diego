﻿using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public Camera cam;

    private int vida = 8;

    public Image Corazon1, Corazon2, Corazon3, Corazon4;

    public bool vivo = true;
    public bool pausado = false;

    public Image pantallaDePerder;

    [HideInInspector]
    public string lugarVictoria;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
                pausado = false;
            else
                pausado = true;
        }

        if (Input.GetMouseButtonDown(1) && vivo == true && pausado == false)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == lugarVictoria)
        {
            if (MisionManager.instance.CompletarMision())
            {
                vivo = false;
                pantallaDePerder.gameObject.SetActive(true);
                pantallaDePerder.GetComponentInChildren<Text>().text = "¡Has ganado!";
                agent.SetDestination(transform.position);
            }
        }

        if (other.tag == "Coche")
        {
            HacerDano(other.gameObject.GetComponent<Coche>().Dano);
        }
    }

    public void Continuar()
    {
        pausado = false;
    }

    public void HacerDano(int dano)
    {
        vida -= dano;

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

        if (vida <= 0)
        {
            Perder();
        }
    }

    public void Perder()
    {
        vivo = false;
        pantallaDePerder.gameObject.SetActive(true);
        agent.SetDestination(transform.position);
    }
  }

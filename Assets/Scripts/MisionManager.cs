﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MisionManager : MonoBehaviour
{
    public GameObject MisionCasaPrincipal;
    public GameObject MisionCasaAbuela;
    public GameObject MisionColegio;
    public GameObject MisionBar;
    public GameObject MisionComisaria;

    [SerializeField]
    GameObject anilloCasaPrincipal;
    [SerializeField]
    GameObject anilloCasaAbuela;
    [SerializeField]
    GameObject anilloColegio;
    [SerializeField]
    GameObject anilloBar;
    [SerializeField]
    GameObject anilloComisaria;

    public Transform[] SpawnPoints;

    private string MisionCasaPrincipalText = "LLEGA A TU CASA";
    private string MisionCasaAbuelaText = "LLEGA A CASA DE LA ABUELA";
    private string MisionColegioText = "LLEGA AL COLEGIO";
    private string MisionBarText = "LLEGA AL BAR";
    private string MisionComisariaText = "LLEGA A LA COMISARÍA";

    private string ColliderCasaPrincipal = "VictoriaCasaPrincipal";
    private string ColliderCasaAbuela= "VictoriaCasaAbuela";
    private string ColliderColegio = "VictoriaColegio";
    private string ColliderBar = "VictoriaBar";
    private string ColliderComisaria = "VictoriaComisaria";

    List<int> misionsCompleted = new List<int>();
    int misionesCompletadas = -1;

    [HideInInspector]
    public int MisionActual;

    [SerializeField]
    private Text MisionText;

    [SerializeField]
    Movimiento player;

    [SerializeField]
    Animator MisionAnim;

    // Singleton
    [HideInInspector]
    public static MisionManager instance;

    void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CompletarMision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayerPosition(Vector3 pos)
    {
        player.agent.enabled = false;
        player.transform.localPosition = pos;
        player.agent.enabled = true;
    }

    public bool CompletarMision()
    {
        anilloCasaPrincipal.SetActive(false);
        anilloCasaAbuela.SetActive(false);
        anilloColegio.SetActive(false);
        anilloBar.SetActive(false);
        anilloComisaria.SetActive(false);

        misionesCompletadas++;

        if (misionesCompletadas >= GameSettings.missionsNeeded)
            return true;

        bool ok = true;

        do
        {
            ok = true;

            MisionActual = Random.Range(1, 6);

            for (int i = 0; i < misionsCompleted.Count; i++)
            {
                if (misionsCompleted.Contains(MisionActual))
                    ok = false;
            }


        } while (!ok);

        if (misionesCompletadas > 0)
            MisionAnim.SetTrigger("NewMision");

        switch (MisionActual)
        {
            case 1:
                MisionText.text = MisionCasaPrincipalText;
                player.lugarVictoria = ColliderCasaPrincipal;
                anilloCasaPrincipal.SetActive(true);
                if(misionesCompletadas == 0)
                    SetPlayerPosition(SpawnPoints[0].position);
                break;
            case 2:
                MisionText.text = MisionCasaAbuelaText;
                player.lugarVictoria = ColliderCasaAbuela;
                anilloCasaAbuela.SetActive(true);
                if (misionesCompletadas == 0)
                    SetPlayerPosition(SpawnPoints[0].position);
                break;
            case 3:
                MisionText.text = MisionColegioText;
                player.lugarVictoria = ColliderColegio;
                anilloColegio.SetActive(true);
                if (misionesCompletadas == 0)
                    SetPlayerPosition(SpawnPoints[2].position);
                break;
            case 4:
                MisionText.text = MisionBarText;
                player.lugarVictoria = ColliderBar;
                anilloBar.SetActive(true);
                if (misionesCompletadas == 0)
                    SetPlayerPosition(SpawnPoints[1].position);
                break;
            case 5:
                MisionText.text = MisionComisariaText;
                player.lugarVictoria = ColliderComisaria;
                anilloComisaria.SetActive(true);
                if (misionesCompletadas == 0)
                    SetPlayerPosition(SpawnPoints[1].position);
                break;
        }

        return false;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class MisionManager : MonoBehaviour
{
    public GameObject MisionCasaPrincipal;
    public GameObject MisionCasaAbuela;
    public GameObject MisionColegio;
    public GameObject MisionBar;
    public GameObject MisionComisaria;

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

    [HideInInspector]
    public int MisionActual;

    [SerializeField]
    private Text MisionText;

    [SerializeField]
    Movimiento player;

    // Start is called before the first frame update
    void Start()
    {
        MisionActual = Random.Range(1,6);
        switch (MisionActual)
        {
            case 1:
                MisionText.text = MisionCasaPrincipalText;
                player.lugarVictoria = ColliderCasaPrincipal;
                SetPlayerPosition(SpawnPoints[0].position);
                break;
            case 2:
                MisionText.text = MisionCasaAbuelaText;
                player.lugarVictoria = ColliderCasaAbuela;
                SetPlayerPosition(SpawnPoints[0].position);
                break;
            case 3:
                MisionText.text = MisionColegioText;
                player.lugarVictoria = ColliderColegio;
                SetPlayerPosition(SpawnPoints[2].position);
                break;
            case 4: MisionText.text = MisionBarText;
                player.lugarVictoria = ColliderBar;
                SetPlayerPosition(SpawnPoints[1].position);
                break;
            case 5:
                MisionText.text = MisionComisariaText;
                player.lugarVictoria = ColliderComisaria;
                SetPlayerPosition(SpawnPoints[1].position);
                break;
        }
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

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MisionCasaPrincipal")
        {

        }
        if(other.tag == "MisionCasaAbuela")
        {

        }
        if (other.tag == "MisionColegio")
        {

        }
        if (other.tag == "MisionBar")
        {

        }
        if(other.tag == "MisionComisaria")
        {

        }
    }*/
}

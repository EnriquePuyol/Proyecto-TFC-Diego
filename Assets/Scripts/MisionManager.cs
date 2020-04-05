using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject MisionCasaPrincipal;
    public GameObject MisionCasaAbuela;
    public GameObject MisionColegio;
    public GameObject MisionBar;
    public GameObject MisionComisaria;

    private string MisionCasaPrincipalText = "Llega a tu casa antes de que se acabe el tiempo";
    private string MisionCasaAbuelaText = "Llega a casa de la abuela antes de que se acabe el tiempo";
    private string MisionColegioText = "Llega al colegio antes de que se acabe el tiempo";
    private string MisionBarText = "Llega al bar antes de que se acabe el tiempo";
    private string MisionComisariaText = "Llega a la comisaria antes de que se acabe el tiempo";

    private int MisionActual;
    private Text MisionText;

    // Start is called before the first frame update
    void Start()
    {
        MisionActual = Random.Range(1,6);
        switch (MisionActual)
        {
            case 1:
                MisionText.text = MisionCasaPrincipalText;
                break;
            case 2:
                MisionText.text = MisionCasaAbuelaText;
                break;
            case 3:
                MisionText.text = MisionColegioText;
                break;
            case 4: MisionText.text = MisionBarText;
                break;
            case 5:
                MisionText.text = MisionComisariaText;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
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
    }
}

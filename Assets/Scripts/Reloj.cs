using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]

    public int tiempoInicial;

    [Tooltip("Escala del tiempo del Reloj")]
    [Range(-10.0f,10f)]
    public float escalaDelTiempo = 1;

    private Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float EscalaDeTiempoCuandoEstePausado, EscalaDeTiempoInicial;
    private bool estaPausado = false;

    public Image pantallaDePerder;
    public Movimiento player;

    // Start is called before the first frame update
    void Start()
    {
        if(GameSettings.IsGameDifficult())
        {
            escalaDelTiempo = -1f;
            tiempoInicial = 300;
        }

        EscalaDeTiempoInicial = escalaDelTiempo;

        myText = GetComponent<Text>();

        tiempoAMostrarEnSegundos = tiempoInicial;


        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDelTiempo;

        tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;

        if(player.vivo == true)
            ActualizarReloj(tiempoAMostrarEnSegundos);
    }

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0)
        {
            tiempoEnSegundos = 0;
            player.Perder();
        }

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        myText.text = textoDelReloj;
    }
}

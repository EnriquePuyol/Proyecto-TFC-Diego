using UnityEngine;

public class Coche : MonoBehaviour
{

    public Cruces CruceInicial;

    private Cruces CruceActual;

    private Cruces SiguienteCruce;

    public float Speed;

    public int Dano;
    

    void Start()
    {
        transform.position = new Vector3(CruceInicial.transform.position.x, transform.position.y, CruceInicial.transform.position.z);
        CruceActual = CruceInicial;

        SiguienteCruce = CruceActual.GetRandomVecino(CruceActual.transform);
        transform.LookAt(SiguienteCruce.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, SiguienteCruce.transform.position, Speed * Time.deltaTime);

        if(transform.position == SiguienteCruce.transform.position)
        {
            CruceActual = SiguienteCruce;
            SiguienteCruce = CruceActual.GetRandomVecino(CruceActual.transform);
            transform.LookAt(SiguienteCruce.transform);
        }
    }
}

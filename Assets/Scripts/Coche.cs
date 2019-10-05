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
        transform.position = new Vector3(CruceInicial.trm.position.x, transform.position.y, CruceInicial.trm.position.z);
        CruceActual = CruceInicial;

        SiguienteCruce = CruceActual.GetRandomVecino(CruceActual.trm);
        transform.LookAt(SiguienteCruce.trm);
    }

   

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, SiguienteCruce.trm.position, Speed * Time.deltaTime);

        if(transform.position == SiguienteCruce.trm.position)
        {
            CruceActual = SiguienteCruce;
            SiguienteCruce = CruceActual.GetRandomVecino(CruceActual.trm);
            transform.LookAt(SiguienteCruce.trm);
        }
    }
}

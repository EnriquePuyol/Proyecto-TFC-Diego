using System.Collections.Generic;
using UnityEngine;

public class Cruces : MonoBehaviour
{
    public Cruces[] vecinos;
    
    public Transform trm;

    public Cruces GetRandomVecino(Transform actual)
    {
        int rand;
        do
        {
            rand = Random.Range(0, vecinos.Length);
        } while (vecinos[rand].trm == actual);

        return vecinos[rand];
    }

}

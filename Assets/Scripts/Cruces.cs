using System.Collections.Generic;
using UnityEngine;

public class Cruces : MonoBehaviour
{
    public Cruces[] vecinos;

    Transform trm;

    void Start()
    {
        trm = transform;
    }

    public Cruces GetRandomVecino(Transform actual)
    {
        int rand;
        do
        {
            rand = Random.Range(0, vecinos.Length);
        } while (vecinos[rand].transform == actual);

        return vecinos[rand];
    }

    public Transform Trm()
    {
        return trm;
    }

}

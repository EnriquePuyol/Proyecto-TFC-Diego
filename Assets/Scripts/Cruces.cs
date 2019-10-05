using System.Collections.Generic;
using UnityEngine;

public class Cruces : MonoBehaviour
{
    public Cruces[] vecinos;
    [HideInInspector]
    public Transform trm;

    private void Start()
    {
        trm = transform;
    }

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

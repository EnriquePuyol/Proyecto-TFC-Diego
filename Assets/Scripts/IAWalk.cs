using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAWalk : MonoBehaviour
{
    public float Speed = 4.0f;
    public Vector3[] posiciones;
    int indexActual = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = posiciones[0];
        transform.LookAt(posiciones[indexActual]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posiciones[indexActual], Speed * Time.deltaTime);

        if (transform.position == posiciones[indexActual])
        {
            if(indexActual == posiciones.Length - 1)
            {
                indexActual = 0;
            }
            else
            {
                indexActual++;
            }
            
            transform.LookAt(posiciones[indexActual]);
        }
    }
}

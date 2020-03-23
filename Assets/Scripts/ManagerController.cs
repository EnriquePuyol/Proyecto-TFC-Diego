using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerController : MonoBehaviour
{
    private bool pausado = false;

    public Animator pausaAnim;
    public Image pausaFondo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        if (pausado == false)
        {
            pausaAnim.SetTrigger("Pausa");
            pausaFondo.gameObject.SetActive(true);
            pausado = true;
            Time.timeScale = 0;
        }
        else
        {
            pausaAnim.SetTrigger("Continuar");
            pausaFondo.gameObject.SetActive(false);
            pausado = false;
            Time.timeScale = 1;
        }
    }

    IEnumerator LoadLevel(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    public void BackToMenu(int scene)
    {
        pausado = false;
        StartCoroutine(LoadLevel(scene));
    }
}   

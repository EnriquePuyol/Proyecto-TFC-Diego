using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public Image LoadingImage;

    public Text Percentage;
    public Text difficultText;

    public void PlayEasy(int scene)
    {
        GameSettings.SetGameDifficulty(false);
        LoadGame(scene);
    }

    public void PlayChallenge(int scene)
    {
        GameSettings.SetGameDifficulty(true);
        LoadGame(scene);
    }

    public void LoadGame(int scene)
    {
        LoadingImage.gameObject.SetActive(true);
        StartCoroutine(LoadLevel(scene));
    }

    public void Options()
    {

    }
    
    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Percentage.text = progress * 100f + "%";
            yield return null;
        }     
         
    }
}

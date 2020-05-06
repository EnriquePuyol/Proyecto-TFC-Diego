using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    Camera MainCamera;

    [SerializeField]
    Camera MapCamera;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    Movimiento player;

    bool mapEnable = false;

    void Start()
    {
        MainCamera.enabled = true;
        MapCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.M) && !GameSettings.IsGameDifficult())
        {
            if(mapEnable == false)
            {
                mapEnable = true;

                MainCamera.enabled = false;
                MapCamera.enabled = true;

                canvas.SetActive(false);
                player.pausado = true;
            }
            else
            {
                mapEnable = false;

                MainCamera.enabled = true;
                MapCamera.enabled = false;

                canvas.SetActive(true);
                player.pausado = false;
            }
        }
    }
}

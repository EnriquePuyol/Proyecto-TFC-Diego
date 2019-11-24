using UnityEngine.UI;
using UnityEngine;

public class Boton : MonoBehaviour
{

    public Color originalColor;

    public Color hoverColor;

    public Image imagen;

    public void HoverColor()
    {
        imagen.color = hoverColor;
    }
    
    public void OriginalColor()
    {
        imagen.color = originalColor; 
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UI_Shop_Fades : MonoBehaviour
{
    public float fadeTime = 1f;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;

    private Image image;
    private float currentAlpha = 0.6f;
    private bool fadingIn = false;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (fadingIn)
        {
            currentAlpha += Time.deltaTime / fadeTime;
            if (currentAlpha >= maxAlpha)
            {
                currentAlpha = maxAlpha;
                fadingIn = false;
            }
        }
        else
        {
            currentAlpha -= Time.deltaTime / fadeTime;
            if (currentAlpha <= minAlpha)
            {
                currentAlpha = minAlpha;
                fadingIn = true;
            }
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
    }
}


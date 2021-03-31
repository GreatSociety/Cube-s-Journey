using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    CanvasRenderer icon;
    Text text;


    private void Start()
    {
        icon = GetComponent<CanvasRenderer>();
        text = icon.GetComponentInChildren<Text>();

        InventoryControl.FadeIng += ReUpdate;

        icon.SetAlpha(0f);
        text.canvasRenderer.SetAlpha(0f);

    }

    IEnumerator FadeRoutine()
    {
        icon.SetAlpha(1f);
        text.canvasRenderer.SetAlpha(1f);

        yield return new WaitForSeconds(3);

        for (float f = 1f; f >= 0; f -=0.05f)
        {
            icon.SetAlpha(f);
            text.canvasRenderer.SetAlpha(f);
            yield return new WaitForSeconds(0.15f);
        }

        icon.SetAlpha(0f);
        text.canvasRenderer.SetAlpha(0f);
    }

    void ReUpdate()
    {
        StartCoroutine(FadeRoutine());
    }
}

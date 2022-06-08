using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour
{
    public Image image;
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    public void SetAlpha255()
    {
        var alphaColor = image.color;
        alphaColor.a = 1f;
        image.color = alphaColor;
    }
    public void SetAlpha200()
    {
        var alphaColor = image.color;
        alphaColor.a = 0.8f;
        image.color = alphaColor;
    }
    public void SetAlpha130()
    {
        var alphaColor = image.color;
        alphaColor.a = 0.6f;
        image.color = alphaColor;
    }
    public void SetAlpha90()
    {
        var alphaColor = image.color;
        alphaColor.a = 0.4f;
        image.color = alphaColor;
    }
    public void SetAlpha50()
    {
        var alphaColor = image.color;
        alphaColor.a = 0.2f;
        image.color = alphaColor;
    }
}

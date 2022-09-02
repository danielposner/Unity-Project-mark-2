using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadImage : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvas;
    public string PDFstring;
    public float width = 100;
    public float height = 100;
    private Sprite img1;
    public GameObject MyImage;
    public string spriteString;


    void Start()
    {
        spriteString = PDFMenuScript.instance.PDFstring; // Placeholder from carryover




        GameObject newObject = new GameObject("ObjectName");
        RectTransform rectTransform = newObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(1500, 2750);
        Image image = newObject.AddComponent<Image>();
        //image.sprite = sprite;
        image.sprite = Resources.Load<Sprite>(spriteString);
        newObject.transform.SetParent(canvas.transform, false);
    }
}

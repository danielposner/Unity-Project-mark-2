using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericVariablePasser : MonoBehaviour
{
    // This code stops the players selection from being destroyed. It is passed through the non-homepage pages so the players can cycle through them without
    // having to re-input variables

    public static PDFMenuScript instance;

    public void triggerOnClick()
    {
    }

    private void Awake()
    {
        DontDestroyOnLoad(instance.gameObject);
    }
}

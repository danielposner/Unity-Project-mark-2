using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMark2 : MonoBehaviour
{
    public Dropdown d1;

    private void Start()
    {
        d1.onValueChanged.AddListener(delegate
        {
            ValueChangeHappened(d1);
        });
    }

    public void ValueChangeHappened(Dropdown sender)
    {
        Debug.Log("You have selected" + sender.value);
        Debug.Log(d1.options[d1.value].text);
    }
}


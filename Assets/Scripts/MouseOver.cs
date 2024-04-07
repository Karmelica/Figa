using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    public GameObject toolTip;

    public void OnMouseOn()
    {
        toolTip.SetActive(true);
    }
    public void OnMouseOff()
    {
        toolTip.SetActive(false);
    }
}

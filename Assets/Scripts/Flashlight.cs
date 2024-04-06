using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Flashlight : MonoBehaviour
{
    public Transform flashlightDown;
    public Transform flashlightUp;
    public float multi;

    public void Aim()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = Vector3.Lerp(transform.position, flashlightUp.position, Time.deltaTime * multi);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, flashlightDown.position, Time.deltaTime * multi);
        }
    }
    void Update()
    {
        Aim();
    }
}

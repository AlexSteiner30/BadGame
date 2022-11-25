using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootingPos;
    public GameObject bullet;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetMouseButton(0))
            Shooting();
    }

    private void Shooting()
    {
    
    }
}

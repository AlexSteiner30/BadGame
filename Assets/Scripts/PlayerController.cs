using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shootingPos;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
            Shooting();
    }

    private void Shooting()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 40);

        Debug.DrawRay(transform.position, transform.forward, Color.red, 1);

        print("Shooting");
    }
}

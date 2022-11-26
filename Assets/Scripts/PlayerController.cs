using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public PhotonView photonView;

    public GameObject shootingPos;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if(!photonView.IsMine)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

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

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        print("Shooting");
    }
}

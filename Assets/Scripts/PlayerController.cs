using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PhotonView photonView;
    public GameObject shootingPos;
    public Button shootingButton;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if(!photonView.IsMine)
        {
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
        }

        else
        {
            shootingButton = GameObject.Find("ShootingButton").GetComponent<Button>();
            shootingButton.onClick.AddListener(Shooting);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shooting();
    }

    private void Shooting()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 40);

        Vector2 forward = transform.TransformDirection(Vector2.right) * 10;
        Debug.DrawRay(transform.position, forward, Color.green, 1);

        print("Shooting");
    }
}

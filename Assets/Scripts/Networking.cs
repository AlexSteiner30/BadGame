using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Networking : MonoBehaviourPunCallbacks
{
    public Camera camera;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        GameObject instantiatePlayer = PhotonNetwork.Instantiate("Player", new Vector2(0f, 0f), Quaternion.identity);

        GameObject.Find("Main Camera").GetComponent<CameraController>().player = instantiatePlayer.transform;
    }
}

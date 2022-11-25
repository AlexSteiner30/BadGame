using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Networking : MonoBehaviourPunCallbacks
{
    public GameObject offlinePlayer;

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
        PhotonNetwork.Instantiate("Player", offlinePlayer.transform.position, Quaternion.identity);
        Destroy(offlinePlayer);
    }
}

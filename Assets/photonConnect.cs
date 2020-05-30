using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photonConnect : MonoBehaviour
{
    public string VersioName = "0.1";

    public GameObject section_view_1, section_view_2, section_view_3;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);
        Debug.Log("connecting to photon...");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("we are connected to master ");
    }

    private void OnJoinedLobby()
    {
        section_view_1.SetActive(false);
        section_view_2.SetActive(true);

        Debug.Log("On joined Lobby");
    }

    private void OnDisconnectedFromPhoton()
    {
        section_view_1.SetActive(false);
        section_view_3.SetActive(true);

        Debug.Log("Dis fromm photon services");
    }


}

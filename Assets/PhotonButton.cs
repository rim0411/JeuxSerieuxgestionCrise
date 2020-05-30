using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButton : MonoBehaviour
{
    public GameObject charachterPrefab;
    public GameObject section_view_2 , camra , cara;
    public InputField createRoomInput, joinRoomInput;

    public void OnClickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }
    public void onClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomInput.text);
    }

    private void OnJoinedRoom () 
    {
        
        Debug.Log("We are connected to the room !");
        section_view_2.SetActive(false);
        PhotonNetwork.Instantiate("Prefabs/" + charachterPrefab.name, charachterPrefab.transform.position, Quaternion.identity , 0);
        camra.SetActive(false);
        cara.SetActive(true);

    }
}

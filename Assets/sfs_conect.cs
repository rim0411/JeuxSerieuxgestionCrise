using UnityEngine;
using System.Collections;
using Sfs2X;
using Sfs2X.Core;

public class SFS2X_Connect : MonoBehaviour
{

    public string ServerIP = "127.0.0.1";
    public int ServerPort = 9933;
    private SmartFox sfs;

    void Start()
    {
        sfs = new SmartFox();
        sfs.ThreadSafeMode = true;

        sfs.AddEventListener(SFSEvent.CONNECTION, OnConnection);

        sfs.Connect(ServerIP, ServerPort);
    }

    void OnConnection(BaseEvent e)
    {
        if ((bool)e.Params["success"])
        {
            Debug.Log("Successfully Connected");
        }
        else
        {
            Debug.Log("Connection Failed");
        }
    }

    void Update()
    {
        sfs.ProcessEvents();
    }

    void OnApplicationQuit()
    {
        if (sfs.IsConnected)
            sfs.Disconnect();
    }
}

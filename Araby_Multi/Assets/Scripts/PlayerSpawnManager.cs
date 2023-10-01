using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BNG;
using UnityEngine.SceneManagement;
using System;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public static int _ActiveAvatar = 0;

    [Header("Player Types")]
    [SerializeField]
    private GameObject _PlayerClonePrefab;  

    [Header("Local Player positions")]
    public Transform _LocalPlayerPosition;  
    public BNG.NetworkPlayer networkPlayer;  
      

    bool isFirstLoad = true;
 

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene arg0, LoadSceneMode arg1)
    {
        if(SceneManager.GetActiveScene().name == "MainScene" && !isFirstLoad)
        {
            Destroy(gameObject);
            return;
        }

        GameObject.Find("LocalPlayer").GetComponent<AvatarSelector>().OnSelectAvatar(_ActiveAvatar); 
         
        _LocalPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if (!isFirstLoad)
        {
            GameObject player = PhotonNetwork.Instantiate(_PlayerClonePrefab.name, _LocalPlayerPosition.localPosition, _LocalPlayerPosition.localRotation, 0);

            networkPlayer = player.GetComponent<BNG.NetworkPlayer>();
            if (networkPlayer)
            {
                networkPlayer.transform.name = "MyRemotePlayer";

                player.GetComponent<AvatarSelector>().OnSelectAvatar(_ActiveAvatar);

                networkPlayer.SetRemoteAvatar(player.GetComponent<PhotonView>().ViewID, _ActiveAvatar);

                networkPlayer.AssignPlayerObjects();
            }

            //np.SetPlayerName_Remote(player.GetComponent<PhotonView>().ViewID);

        }
        else
        {
            isFirstLoad = false;
        }
        
        
    }

    public void SetSetRemoteAvatar(int index)
    {
        networkPlayer.GetComponent<AvatarSelector>().OnSelectAvatar(index);
        //photonView.gameObject.GetComponent<PlayerInfo>().SetPlayerName(PhotonNetwork.LocalPlayer.NickName);
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    public void InstantiateViaNetwork()
    {  
        GameObject player = PhotonNetwork.Instantiate(_PlayerClonePrefab.name, _PlayerClonePrefab.transform.localPosition, Quaternion.identity, 0);
        networkPlayer = player.GetComponent<BNG.NetworkPlayer>();
        if (networkPlayer)
        {
            networkPlayer.transform.name = "MyRemotePlayer";
            networkPlayer.AssignPlayerObjects();
        }

        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        //networkPlayer.SetPlayerName_Remote(player.GetComponent<PhotonView>().ViewID);
                  
    }   
}

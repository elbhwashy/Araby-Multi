using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    int cuurentAvatar = 0;
    public GameObject[] Avatars;

    public GameObject activeAvatar;

    private void Start()
    {
        //OnSelectAvatar(0);
    }

    public void OnSelectAvatar(int index)
    {
        for (int i = 0; i < Avatars.Length; i++)
        {
            Avatars[i].SetActive(false);
        }

        Avatars[index].SetActive(true);
        cuurentAvatar = index;
        PlayerSpawnManager._ActiveAvatar = index;
        activeAvatar = Avatars[index];
    } 
}

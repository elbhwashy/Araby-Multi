using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSelector : MonoBehaviour
{
    public GameObject[] Avatars;



    public void OnSelectAvatar(int index)
    {
        for (int i = 0; i < Avatars.Length; i++)
        {
            Avatars[i].SetActive(false);
        }

        Avatars[index].SetActive(true);
    } 
}

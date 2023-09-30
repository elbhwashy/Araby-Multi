using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHandPoserReference : MonoBehaviour
{
    public HandController LHandController;
    public Grabber LHandGrabber;
    public Animator LAnimator;
    public HandPoser LPoser;
    public AutoPoser LAutoPoser;

    [Space]
    public HandController RHandController;
    public Grabber RHandGrabber;
    public Animator RAnimator;
    public HandPoser RPoser;
    public AutoPoser RAutoPoser;


    private void OnEnable()
    {
        LHandController.HandAnimator = LAnimator;
        LHandController.handPoser = LPoser;
        LHandController.autoPoser = LAutoPoser;
        LHandController.grabber = LHandGrabber;

        RHandController.HandAnimator = RAnimator;
        RHandController.handPoser = RPoser;
        RHandController.autoPoser = RAutoPoser;
        RHandController.grabber = RHandGrabber;
    }
     
}

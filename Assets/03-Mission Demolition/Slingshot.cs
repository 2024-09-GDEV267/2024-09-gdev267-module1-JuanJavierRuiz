using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour   
{
    public GameObject launchPoint;

    // fields set in the Unity Inspector pane
    [Header("Inscribed")]
    public GameObject   projectilePrefab;

    // fields set dynamically
    [Header("Dynamic")]
    public GameObject   launchPoint;
    public Vector3      lanuchPos;
    public GameObject   projectile;
    public bool         aimingMode;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");     
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
         // The player has pressed the mouse button while over Slingshot
         aimingMode = true;
         // Instantiate a Projectile
         projectile = Instantiate(projectilePrefab) as GameObject;
         // Start it at the launchPoint
         projectile.transform.position = launchPos;
         // Set it to isKinematic for now
         projectile.GetComponent<Rigidbody>().isKinematic = true;               

    }
}

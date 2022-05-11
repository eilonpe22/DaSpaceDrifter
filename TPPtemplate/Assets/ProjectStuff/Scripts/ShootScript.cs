using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    // Shooting inputs
    public int damage;
    public float FireRate, spread, range, reloadTime, timeBetweenShots,timeToOverHeat;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletShot;
    bool shooting, readyToShoot, reloading;
    private float timer;
    private float overHeatTimer;

    //refrence
    public Camera fpsCam;
    public Transform atackPoint;
    public Transform atackPoint2;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        NormalShot();
        OverHeat();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shooting = true;
        }
        if (context.canceled)
        {
            shooting = false;
        }

        
    }
    void NormalShot()
    {
        if (shooting && allowButtonHold)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenShots)
            {
                timer = 0;
                Instantiate(laser, atackPoint.position, transform.rotation);
                Instantiate(laser, atackPoint2.position, transform.rotation);
            }
           
        }
    }
    void OverHeat()
    {
        if (shooting)
        {
            overHeatTimer += Time.deltaTime;
            if(  overHeatTimer >= timeToOverHeat)
            {
                overHeatTimer = timeToOverHeat;
                allowButtonHold = false;
            }

        }
        if(allowButtonHold == false)
        {
            Debug.Log("WORK");
            overHeatTimer -= Time.deltaTime;
            if(overHeatTimer <= 0)
            {
                overHeatTimer = 0;
                allowButtonHold = true;
                
            }
        }

    }
    

}

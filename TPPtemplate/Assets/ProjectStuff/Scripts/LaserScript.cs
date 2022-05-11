using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float fireSpeed = 10f;
    public float destroyLaser;
    // Start is called before the first frame update
    void Start()
    {
        LaserDMG();
    }

    // Update is called once per frame
    void Update()
    {
        LaserBehavior();
    }
    void LaserBehavior()
    {
        transform.position += transform.forward * fireSpeed * Time.deltaTime;
    }
    void LaserDMG()
    {
        Destroy(gameObject,destroyLaser);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

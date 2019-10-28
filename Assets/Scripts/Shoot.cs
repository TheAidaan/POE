using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : MonoBehaviour
{
    Rigidbody rb;
    float speed = 100f;
    float bulletSpeed = 100f;

    bool inRange = false;

    public GameObject bullet;
    public Transform bulletPos;

    float inputX;
    float inputY;

    float timer;

    private void Start()
    {
        timer = 0f;
    }

    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        timer += Time.deltaTime;
        if (timer < 3)
        {
            inRange = true;
            timer = 0;

            if (inRange)
            {
                Fire();
            }

            inRange = false;

        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);


    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Fire()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);

        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);


        Destroy(bulletSpawn, 2);   //3 is seconds till destroy


        // we need arigidbodu/char controller to allow storing in var
        //we can access velocity
    }
}

    //StartCoroutine(StartShooting());
    //IEnumerator StartShooting()
    //{
    //    yield return new WaitForSeconds(3);
    //    Instantiate(bullet, bulletPos.position, Quaternion.identity);
    //    StartCoroutine(StartShooting);
    //}

//private void FixedUpdate()
//{

//    if (shoot)
//    {
//        Shoot();

//        shoot = false;
//    }
//}


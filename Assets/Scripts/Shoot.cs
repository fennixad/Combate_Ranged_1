using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public int speed;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shooting(speed);
        }
    }

    void Shooting(int speed)
    { 
        GameObject bullet_clone = Instantiate(bullet, this.transform.position, this.transform.rotation * Quaternion.Euler(90, 0, 0));
        Rigidbody rb = bullet_clone.GetComponent<Rigidbody>();
        rb.velocity = this.transform.TransformDirection(new Vector3(0, 0, speed));
    }
}

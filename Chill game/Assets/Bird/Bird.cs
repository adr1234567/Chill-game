using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    
    private Rigidbody rb;

    public float height;
    public float speed;

    void Awake()
    {
        rb  = GetComponent<Rigidbody>();
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);

        FollowPlayer();
    } 

    void FollowPlayer()
    {
        transform.LookAt(target);
        rb.velocity=speed*transform.forward;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    public float height;
    
    private Rigidbody rb;

    public float speed;
    public float attackRange;
    public float damage;
    public float startingHealth;

    public float score;

    public GameObject biteObject;

    void Awake()
    {
        rb  = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;

        transform.GetChild(0).GetComponent<HEalth>().health = startingHealth;
    }


    void Update()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.transform.position.x, target.transform.position.z))<= attackRange)
        {
            Peck();
        } else
        {
            FollowPlayer();
        }
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    } 

    void FollowPlayer()
    {
        transform.LookAt(target);
        rb.velocity=speed*transform.forward;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void Peck()
    {
        rb.velocity = Vector3.zero;

        transform.LookAt(target);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x*0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        anim.SetTrigger("Bite");

        AnimatorClipInfo[ ] clip = anim.GetCurrentAnimatorClipInfo(0);
        int frame = (int) (clip[0].weight * (clip[0].clip.length * clip[0].clip.frameRate));

        if (frame >= 12 & frame <= 14)
        {
            biteObject.SetActive(true);
            Collider[] peckTargets = Physics.OverlapSphere(biteObject.transform.position, 3);

            for(int i = 0; i < peckTargets.Length; i++) {
                if (peckTargets[i].gameObject.tag == "Player")
                {
                    peckTargets[i].transform.parent.GetComponent<HEalth>().health -= damage;
                }
            }
            
        } else
        {
            biteObject.SetActive(false);
        }
    }
}

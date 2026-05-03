using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="Enemy")
        {
            col.transform.parent.gameObject.GetComponent<HEalth>().health-=damage;
            GameObject.Find("Score").GetComponent<Score>().score += col.transform.parent.parent.gameObject.GetComponent<ScoreValue>().scoreAddition * Random.Range(1, 1.5f);
            GameObject.Find("Score").GetComponent<Score>().score *= col.transform.parent.parent.gameObject.GetComponent<ScoreValue>().scoreMultiplier;
        }
        Destroy(gameObject);
    }
}

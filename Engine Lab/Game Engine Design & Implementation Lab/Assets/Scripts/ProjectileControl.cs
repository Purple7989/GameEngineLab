using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance > 50.0f)
        {
            Destroy(gameObject);
        }

    }
}

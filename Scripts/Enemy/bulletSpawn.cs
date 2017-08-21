using UnityEngine;
using System.Collections;

public class bulletSpawn : MonoBehaviour
{

    public float bulletSpeed = 2000.0f;

    void FixedUpdate()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("environment"))
        {
            Destroy(this.gameObject);
        }
    }


}

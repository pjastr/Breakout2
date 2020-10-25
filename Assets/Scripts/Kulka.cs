using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kulka : MonoBehaviour
{
    public float ballInitialVelocity = 600f;
    public GameObject czastki;

    private Rigidbody rb;
    private bool ballInPlay;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Kostka"))
        {
            Instantiate(czastki, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}

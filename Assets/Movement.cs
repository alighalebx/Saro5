using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float rocket = 100f;
    [SerializeField] float rotationThrust = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust(){

        if(Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(Vector3.up * rocket * Time.deltaTime);
            Debug.Log("byteer");
        }

    }

    void ProcessRotation(){


        if(Input.GetKey(KeyCode.A))
        {
        ApplyRotation(rotationThrust);

        }

        else if(Input.GetKey(KeyCode.D))
        {
        ApplyRotation(-rotationThrust);

        }


    }


    void ApplyRotation(float rot)
    {


        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rot * Time.deltaTime);
        rb.freezeRotation= false;
    }


}

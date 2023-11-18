using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    Rigidbody rigi;
    public float fuerzaNave = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 2);
        //transform.Rotate(Vector3.right * 2);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rigi.AddForce(Vector3.up * fuerzaNave);
        //}
    }
}

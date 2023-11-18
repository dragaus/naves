using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    Rigidbody rigi;
    public LayerMask queEsMuerte;
    public float fuerzaNave = 1000;
    public float fuerzaRotacion = 30;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.right * 2);

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -fuerzaRotacion * Time.deltaTime);    
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * fuerzaRotacion * Time.deltaTime);    
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
           rigi.AddForce(transform.up * fuerzaNave);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(( queEsMuerte & (1 << collision.collider.gameObject.layer)) != 0)
        {
            Debug.Log(collision.collider.gameObject.layer);
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

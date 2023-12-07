using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour
{
    Rigidbody rigi;
    public LayerMask queEsMuerte;
    public float fuerzaNave = 1000;
    public float fuerzaRotacion = 30;
    public bool estaDestruida = false;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        //int numeroHijos = transform.GetChild(0).childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.estamosJugando) return;
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
        if (estaDestruida) return;

        if(( queEsMuerte & (1 << collision.collider.gameObject.layer)) != 0)
        {
            StartCoroutine(DestruirNave());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("�Gane!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            manager.AgregarMoneda();
        }
    }

    public IEnumerator DestruirNave()
    {
        Debug.Log("Hola");
        estaDestruida = true;
        //Es vamos a esperar exactamente 1 segundo antes de avanzar a la siguiente instruccion
        VolarComponentes();
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Adios");
    }

    void VolarComponentes() 
    {
        int numeroHijos = transform.childCount;

        for (int i = 0; i < numeroHijos; i++)
        {
            Debug.Log(i);
            //Destroy(rigi);
            GameObject hijo = transform.GetChild(i).gameObject;

            //(1,1,1) * 2
            Rigidbody hijoRigi = hijo.AddComponent<Rigidbody>();

            int x = Random.Range(-1000, 1000);
            int y = Random.Range(-1000, 1000);
            int z = Random.Range(-1000, 1000);

            Vector3 direccion = new Vector3(x, y, z);

            hijoRigi.AddForce(direccion);

            //ctr + k, ctr + c esto comenta
            //ctr + k, ctr + u quita comentario
            int xR = Random.Range(0, 360);
            int yR = Random.Range(0, 360);
            int zR = Random.Range(0, 360);

            Vector3 rotacion = new Vector3(xR, yR, zR);

            transform.rotation = Quaternion.Euler(rotacion);

            hijoRigi.AddForceAtPosition(direccion, Vector3.down);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Boton3D : MonoBehaviour
{
    public UnityAction action;
    public Material baseMaterial;
    public Material onHover;

    [SerializeField]
    MeshRenderer rnd;

    void OnMouseEnter()
    {
        rnd.material = onHover;
    }

    void OnMouseExit()
    {
        rnd.material = baseMaterial;
    }

    void OnMouseDown()
    {
        action();
        // SceneManager.LoadScene(1);
    }
}

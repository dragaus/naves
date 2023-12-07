using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Boton3D : MonoBehaviour
{
    public UnityEvent action;
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
        action.Invoke();
    }
}

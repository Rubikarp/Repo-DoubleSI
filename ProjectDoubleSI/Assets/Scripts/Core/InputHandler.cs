using System;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [Header("reférence")]
    public Camera cam;
    public Transform camTransf;

    [Header("Internal Value")]
    public Plane inputSurf = new Plane(Vector3.back, Vector3.zero);
    [Space(10)]
    [SerializeField] public Ray ray;
    [SerializeField] public float hitDist = 0f;
    [SerializeField] public Vector3 hitPoint = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

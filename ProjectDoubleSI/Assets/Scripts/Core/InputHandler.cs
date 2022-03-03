using UnityEngine.Events;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class InputHandler : MonoBehaviour
{
    [Header("reférence")]
    public Camera cam;
    public Transform camTransf;

    [Header("Internal Value")]
    public Plane inputSurf = new Plane(Vector3.up, Vector3.zero);
    [Space(10)]
    [SerializeField] public Ray ray;
    [SerializeField] public float hitDist = 0f;
    [SerializeField] public Vector3 hitPoint = Vector3.zero;

    public bool isMaintaining = false;

    [Header("Event")]
    public UnityEvent onInputPress;
    public UnityEvent onInputMaintain;
    public UnityEvent onInputRelease;

    void Update()
    {

        GetHitPos();

        //OnPress
        if (Input.GetMouseButtonDown(0))
        {
            if (!KarpHelper.IsOverUI())
            {
                isMaintaining = true;
                onInputPress?.Invoke();
            }
        }
        //OnDrag
        if (Input.GetMouseButton(0))
        {
            if (KarpHelper.IsOverUI())
            {
                onInputRelease?.Invoke();
            }
            else
            if (isMaintaining)
            {
                onInputMaintain?.Invoke();
            }
        }
        //OnRelease
        if (Input.GetMouseButtonUp(0))
        {
            if (isMaintaining)
            {
                isMaintaining = false;
                onInputRelease?.Invoke();
            }
        }
    }

    //Méthodes
    public Vector3 GetHitPos()
    {
        //Reset HitPoint
        hitPoint = Vector3.zero;
        //Get Ray
        ray = cam.ScreenPointToRay(Input.mousePosition);
        //Raycast
        if (inputSurf.Raycast(ray, out hitDist))
        {
            hitPoint = ray.GetPoint(hitDist);
        }
        else
        {
            Debug.LogError("Ray parrallèle to plane", this);
        }
        return hitPoint;
    }
    private void OnDrawGizmosSelected()
    {
        float dist = 12f;
        Debug.DrawLine(new Vector3(-1, 0, 01) * dist, new Vector3(01, 0, 01) * dist, Color.blue);
        Debug.DrawLine(new Vector3(01, 0, 01) * dist, new Vector3(01, 0, -1) * dist, Color.blue);
        Debug.DrawLine(new Vector3(01, 0, -1) * dist, new Vector3(-1, 0, -1) * dist, Color.blue);
        Debug.DrawLine(new Vector3(-1, 0, -1) * dist, new Vector3(-1, 0, 01) * dist, Color.blue);

        Debug.DrawLine(hitPoint, hitPoint + Vector3.up, Color.cyan);
    }
}

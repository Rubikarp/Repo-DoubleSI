using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticuleLife : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;

    void Start()
    {
        var main = ps.main;
        Invoke("Suicide", main.duration);
    }

    void Suicide()
    {
        Destroy(transform.gameObject);
    }
}

using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] float dur = 0.3f;

    private void OnEnable()
    {
        Invoke("Disable", dur);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    public UnityEvent MyEvent;
    void Start()
    {
        MyEvent?.Invoke();
    }
}

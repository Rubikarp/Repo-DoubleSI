using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class FoodEvent : UnityEvent<FoodItem> { }

public class FoodItem : MonoBehaviour
{
    [SerializeField, Expandable]
    private FoodSCO food;
    public FoodSCO Food 
    {
        get { return food; }
        set 
        { 
            food = value;
            onChangingFood?.Invoke(this);
        } 
    }
    public FoodEvent onChangingFood;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

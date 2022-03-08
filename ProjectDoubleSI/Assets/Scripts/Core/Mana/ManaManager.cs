using UnityEngine;
using UnityEngine.Events;

public class ManaManager : MonoBehaviour
{
     public int AvailableMana { get { return availableMana; } }
    [SerializeField, Range(0, 10)] private int availableMana = 0;
    public int MaxMana { get { return maxMana; } }
    [SerializeField, Range(0, 10)] private int maxMana = 4;
    [Space(10)]
    public UnityEvent onManaChange;
    public UnityEvent onMaxManaChange;

    private void Start()
    {
        availableMana = 0;
        onManaChange?.Invoke();
    }

    public void OnValidate()
    {
        availableMana = Mathf.Clamp(availableMana, 0, maxMana);
        onManaChange?.Invoke();
        onMaxManaChange?.Invoke();
    }

    public void MaxManaUp(int value)
    {
        maxMana += value;
        onMaxManaChange?.Invoke();
    }

    public bool CanCast(int castCost)
    {
        return availableMana >= castCost;
    }
    public void AddMana(int value)
    {
        availableMana = Mathf.Clamp(availableMana + value, 0, maxMana);
        onManaChange?.Invoke();
    }
    public void LoseMana(int castCost)
    {
        availableMana = Mathf.Clamp(availableMana - castCost, 0, maxMana); ;
        onManaChange?.Invoke();
    }
}

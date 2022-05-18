using System;
using UnityEngine;

public class Body : MonoBehaviour 
{     
    [SerializeField] private int _bodyDamageMultiplier = 1; 
    public event Action<int> WeaponVisited;

    public void PistolVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _bodyDamageMultiplier);
    }

    public void AutomateVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _bodyDamageMultiplier);
    }

    public void GrenadeVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _bodyDamageMultiplier);
    }
}

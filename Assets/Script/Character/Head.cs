using System;
using UnityEngine;

public class Head : MonoBehaviour, IWeaponVisit
{
    [SerializeField] private int _headDamageMultiplier = 3; 
    public event Action<int> WeaponVisited;

    public void PistolVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _headDamageMultiplier);
    }

    public void AutomateVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _headDamageMultiplier);
    }

    public void GrenadeVisit(int damage)
    {
        WeaponVisited.Invoke(damage * _headDamageMultiplier);
    }
}

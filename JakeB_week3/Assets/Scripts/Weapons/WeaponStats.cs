using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/WeaponStats", order = 1)]
public class WeaponStats : ScriptableObject {
    public string weaponName;
    public int damage;
    public float range;
    public float fireRate; // Shots per second
    public float timeToNextFire; // Time between shots
    public int numberOfProjectiles = 1; // For shotguns or other multi-projectile weapons
    public float aimConeAngle = 0f; // For shotguns or spread weapons
}
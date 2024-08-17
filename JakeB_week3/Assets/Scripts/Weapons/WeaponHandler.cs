using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour {

    public WeaponStats weaponStats;
    public GameObject projectilePrefab;
    private PlayerControls controls;

    public Transform firePoint;
    private float timeSinceLastShot = 0f;

    void Awake() {
        controls = new PlayerControls();
    }

    void OnEnable() {
        controls.Player.Enable();
    }

    void OnDisable() {
        controls.Player.Disable();
    }

    void Update() {
        // Fire if the left mouse button is pressed and the cooldown is complete
        if (controls.Player.Fire.ReadValue<float>() > 0 && Time.time >= timeSinceLastShot + weaponStats.timeToNextFire) {
            FireWeapon();
            timeSinceLastShot = Time.time;
        }
    }

    void FireWeapon() {
        if (weaponStats.numberOfProjectiles > 1) {
            // Shotgun or spread weapon logic
            for (int i = 0; i < weaponStats.numberOfProjectiles; i++) {
                Quaternion spreadRotation = Quaternion.Euler(0, Random.Range(-weaponStats.aimConeAngle, weaponStats.aimConeAngle), 0);
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * spreadRotation);
                ProjectileMovement projectileMovement = projectile.GetComponent<ProjectileMovement>(); {
                    projectileMovement.weaponStats = weaponStats;
                }
            }
        } else {
            // Single shot logic
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            ProjectileMovement projectileMovement = projectile.GetComponent<ProjectileMovement>(); {
                projectileMovement.weaponStats = weaponStats;
            }
        }
    }
}
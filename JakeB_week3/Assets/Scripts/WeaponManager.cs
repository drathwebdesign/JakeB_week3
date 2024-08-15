using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public GameObject[] weapons; // Array to hold weapon GameObjects
    private int currentWeaponIndex = 0;

    void Start() {
        // Initialize by enabling the first weapon and disabling the rest
        SelectWeapon(currentWeaponIndex);
    }

    void Update() {
        // Switch to the previous weapon with Q
        if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchWeapon(-1);
        }

        // Switch to the next weapon with E
        if (Input.GetKeyDown(KeyCode.E)) {
            SwitchWeapon(1);
        }
    }

    void SwitchWeapon(int direction) {
        // Disable the current weapon
        weapons[currentWeaponIndex].SetActive(false);

        // Calculate the new weapon index
        currentWeaponIndex += direction;

        // Wrap around the index if it goes out of bounds
        if (currentWeaponIndex >= weapons.Length) {
            currentWeaponIndex = 0;
        } else if (currentWeaponIndex < 0) {
            currentWeaponIndex = weapons.Length - 1;
        }

        // Enable the new weapon
        SelectWeapon(currentWeaponIndex);
    }

    void SelectWeapon(int index) {
        // Enable the selected weapon and disable the others
        for (int i = 0; i < weapons.Length; i++) {
            weapons[i].SetActive(i == index);
        }
    }
}
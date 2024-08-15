using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour {
    private RectTransform crosshairTransform;
    private PlayerControls controls;

    void Awake() {
        controls = new PlayerControls();
        controls.Player.Enable();

        crosshairTransform = GetComponent<RectTransform>();
    }

    void Start() {
        Cursor.visible = false;
    }


    void Update() {
        // Get the mouse position from the Input System
        Vector2 mousePosition = controls.Player.Look.ReadValue<Vector2>();

        // Update the position of the crosshair
        crosshairTransform.position = mousePosition;
    }

    void OnEnable() {
        controls.Player.Enable();
    }

    void OnDisable() {
        controls.Player.Disable();
    }
}
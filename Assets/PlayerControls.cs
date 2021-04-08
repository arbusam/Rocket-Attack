using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    [Header("Controls")]
    [Tooltip("The controls for moving the ship")] [SerializeField] InputAction movement;
    [Tooltip("The button to fire lasers")] [SerializeField] InputAction fire;

    [Header("Movement")]
    [Tooltip("The speed the rocket moves at")] [SerializeField] float movementSpeed = 1f;
    [Tooltip("The movement range of the rocket when moving on a horizontal axis")] [SerializeField] float zRange = 5f;
    [Tooltip("The movement range of the rocket when moving on a vertical axis")] [SerializeField] float yRange = 5f;

    [Header("Rotation")]
    [Tooltip("The rocket's position's pitch factor")] [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("The rocket's control's pitch factor")] [SerializeField] float controlPitchFactor = -10f;

    [Tooltip("The rocket's position's yaw factor")] [SerializeField] float positionYawFactor = 2f;

    [Tooltip("The rocket's controls's roll factor")] [SerializeField] float controlRollFactor = -20f;

    [Header("GameObjects")]
    [Tooltip("The rocket's lasers")] [SerializeField] GameObject[] lasers;

    float zThrow;
    float yThrow;
    
    void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessRotation()
    {

        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float controlPitch = yThrow * controlPitchFactor;

        float pitch = positionPitch + controlPitch;
        float yaw = transform.localPosition.z * positionYawFactor;
        float roll = zThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw + -101.995f, roll);
    }

    private void ProcessTranslation()
    {
        zThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float zOffset = zThrow * Time.deltaTime * movementSpeed;
        float rawZPos = transform.localPosition.z + zOffset;
        float clampedZPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        float yOffset = yThrow * Time.deltaTime * movementSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, clampedZPos);
    }

    private void ProcessFiring()
    {
        if (fire.ReadValue<float>() > 0.5) {
            SetLasersActive(true);
        } else
        {
            SetLasersActive(false);
        }

    }

    private void SetLasersActive(bool isActive)
    {

        foreach (GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isActive;
        }

    }
}

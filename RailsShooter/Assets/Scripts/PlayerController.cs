using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 2f;
    [Tooltip("in ms^-1")] [SerializeField] float xSpeed =10f;
    [Tooltip("in ms^-1")] [SerializeField] float ySpeed = 8f;
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -3f;
    [SerializeField] float controlRollFactor = -5f;
    float xThrow, yThrow;
    [SerializeField]
    Joystick playStick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToControlThrow + pitchDueToPosition;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
       // xThrow = playStick.Horizontal;
       // yThrow = playStick.Vertical;
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float posX = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float posY = Mathf.Clamp(rawNewYPos, -yRange, yRange);
        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);
    }
}

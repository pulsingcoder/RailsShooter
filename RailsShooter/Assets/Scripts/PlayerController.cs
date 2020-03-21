using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Tooltip("in ms^-1")] [SerializeField] float xSpeed =4f;
    [Tooltip("in ms^-1")] [SerializeField] float ySpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float posX = Mathf.Clamp(rawNewXPos, -5f, 5f);
        float posY = Mathf.Clamp(rawNewYPos, -2f, 2f);
        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float movementSpeed = 3f;    
    [SerializeField]float movementBiMultiplay = 0.8f;
    float movementSpeedBi;
    float sprintMultiply = 2f;
    bool sprintIndicator = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeedBi = movementSpeed * movementBiMultiplay;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        SprintToggle();
    }

    void MovePlayer()
    {
        float xAxisInput = Input.GetAxisRaw("Horizontal");
        float zAxisInput = Input.GetAxisRaw("Vertical");

        if(xAxisInput != 0 && zAxisInput != 0)
        {

            if (!sprintIndicator)
            {
                transform.Translate(new Vector3(xAxisInput * movementSpeedBi * Time.deltaTime, 0, zAxisInput * movementSpeedBi * Time.deltaTime));
            }
            else
            {
                transform.Translate(new Vector3(xAxisInput * movementSpeedBi * sprintMultiply * Time.deltaTime, 0, zAxisInput * movementSpeedBi * sprintMultiply * Time.deltaTime));
            }
        }
        else if (xAxisInput != 0 || zAxisInput != 0)
        {
            if (!sprintIndicator)
            {
                transform.Translate(new Vector3(xAxisInput * movementSpeed * Time.deltaTime, 0, zAxisInput * movementSpeed * Time.deltaTime));
            }            
            else
            {
                transform.Translate(new Vector3(xAxisInput * movementSpeed * sprintMultiply * Time.deltaTime, 0, zAxisInput * movementSpeed * sprintMultiply * Time.deltaTime));
            }
        }
    }

    void SprintToggle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sprintIndicator = !sprintIndicator;
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float rotationSpeed;
    public float scaleIncreaseRate;
    private Vector3 scale;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        counter = 0;

        InvokeRepeating("IncreaseSize", 0, 0.05f);
        InvokeRepeating("DecreaseSize", 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        CubeRotation();
    }


    // This method checks the horizontal and vertical input and rotates the cube accordingly
    void CubeRotation()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * verticalInput * rotationSpeed);
    }

    // This method increases the size if space is called and keeps a record of incremention
    void IncreaseSize()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleIncreaseRate, transform.localScale.y + scaleIncreaseRate, transform.localScale.z + scaleIncreaseRate);
            counter++;
        }
    }

    // This method decreases the size if space is not pressed and the size of the cube has increased because of incrementation
    void DecreaseSize()
    {
        if(counter > 0 && !Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x - scaleIncreaseRate, transform.localScale.y - scaleIncreaseRate, transform.localScale.z - scaleIncreaseRate);
            counter--;
        }
    }
}

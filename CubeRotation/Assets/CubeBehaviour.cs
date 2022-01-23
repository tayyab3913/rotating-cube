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
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * verticalInput * rotationSpeed);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleIncreaseRate, transform.localScale.y + scaleIncreaseRate, transform.localScale.z + scaleIncreaseRate);
            counter++;
        } else if(Input.GetKeyUp(KeyCode.Space))
        {
            transform.localScale = scale;
        }
    }

//This method could be used to gradually decrease the size but it works without this method so I stopped improving it
    void DecreaseSize()
    {
        for (int i = counter; i > 1; i--)
        {
            transform.localScale = new Vector3(transform.localScale.x - scaleIncreaseRate, transform.localScale.y - scaleIncreaseRate, transform.localScale.z - scaleIncreaseRate);
        }
        counter = 0;
    }
}

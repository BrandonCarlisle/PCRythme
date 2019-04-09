using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject purp;
    public GameObject orange;
    public GameObject blue;
    public GameObject green;
    public GameObject yellow;
    public GameObject red;

    Vector3 orangeVector = new Vector3(0.0f, 0.763f, 0.0f);
    Vector3 blueVector = new Vector3(0.0f, 1.583f, 0.0f);
    Vector3 greenVector = new Vector3(0.0f, 2.328f, 0.0f);
    Vector3 yellowVector = new Vector3(0.0f, 3.024f, 0.0f);
    Vector3 redVector = new Vector3(0.0f, 3.615f, 0.0f);

    Vector3 offsetPurp = new Vector3(0.0f, 2.0f, 0.0f);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("d"))
        {
            GameObject purpClone = Instantiate(purp, purp.transform.position + offsetPurp, Quaternion.identity);
            Destroy(purpClone, 0.5f);
        }

        else if (Input.GetKeyDown("f"))
        {
            GameObject orangeClone = Instantiate(orange, orange.transform.position - orangeVector, Quaternion.identity);
            Destroy(orangeClone, 0.5f);
        }
        else if (Input.GetKeyDown("h"))
        {
            GameObject blueClone = Instantiate(blue, blue.transform.position - blueVector, Quaternion.identity);
            Destroy(blueClone, 0.5f);
        }
        else if (Input.GetKeyDown("j"))
        {
            GameObject greenClone = Instantiate(green, green.transform.position - greenVector, Quaternion.identity);
            Destroy(greenClone, 0.5f);
        }
        else if (Input.GetKeyDown("k"))
        {
            GameObject yellowClone = Instantiate(yellow, yellow.transform.position - yellowVector, Quaternion.identity);
            Destroy(yellowClone, 0.5f);
        }
        else if (Input.GetKeyDown("l"))
        {
            GameObject redClone = Instantiate(red, red.transform.position - redVector, Quaternion.identity);
            Destroy(redClone, 0.5f);
        }


    }
}

//purpClone =  Instantiate(purp, purp.transform.position, Quaternion.identity);
//Destroy(purpClone, 1);
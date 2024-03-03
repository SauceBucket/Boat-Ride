using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public Water water;

    void Update()
    {
        
        doBuoyandInput();

    }

    private void doBuoyandInput() {
        float waterHeight = water.GetHeightAtPosition(transform.position);
        Vector3 waterNormal = water.GetNormalAtPosition(transform.position);

        doInput(waterHeight);

        transform.position = new Vector3(transform.position.x, waterHeight, transform.position.z);
        transform.up = waterNormal;
    }
    private void doInput(float height)
    {
        //float waterHeight = water.GetHeightAtPosition(transform.position);
        //Vector3 waterNormal = water.GetNormalAtPosition(transform.position);

        
      
    }

}

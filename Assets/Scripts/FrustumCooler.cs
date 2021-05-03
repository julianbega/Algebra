using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustumCooler : MonoBehaviour
{
    Vector3 point0 = new Vector3(0.0f, 14.0f, 0.0f);
    Vector3 point1 = new Vector3(-1.0f, 15.0f, 0.0f);
    Vector3 point2 = new Vector3(-1.0f, 13.0f, 0.0f);
    Vector3 point3 = new Vector3(1.0f, 13.0f, 0.0f);
    Vector3 point4 = new Vector3(1.0f, 15.0f, 0.0f);
    Vector3 point5 = new Vector3(-150.0f, 300.0f, 500.0f);
    Vector3 point6 = new Vector3(-150.0f, -100.0f, 500.0f);
    Vector3 point7 = new Vector3(150.0f, -100.0f, 500.0f);
    Vector3 point8 = new Vector3(150.0f, 300.0f, 500.0f);

    Vector3 pointToTestInside = new Vector3(2.5f, 2.5f, 2.5f);

    Plane planoBottom;
    Plane planoTop;
    Plane planoFront;
    Plane planoBack;
    Plane planoLeft;
    Plane planoRight;

    public GameObject FrustumPointBase;
    public GameObject FrustumBase1;
    public GameObject FrustumBase2;
    public GameObject FrustumBase3;
    public GameObject FrustumBase4;
    public GameObject FrustumPoint1;
    public GameObject FrustumPoint2;
    public GameObject FrustumPoint3;
    public GameObject FrustumPoint4;

    public GameObject[] InGameObjects;


    void Start()
    {
        planoBottom = new Plane(FrustumPoint3.transform.position, FrustumPoint2.transform.position, FrustumPointBase.transform.position);
        planoTop = new Plane(FrustumPoint1.transform.position, FrustumPoint4.transform.position, FrustumPointBase.transform.position);
        planoBack = new Plane(FrustumPoint3.transform.position, FrustumPoint1.transform.position);
        planoLeft = new Plane(FrustumPoint3.transform.position, FrustumPoint4.transform.position, FrustumPointBase.transform.position);
        planoRight = new Plane(FrustumPoint1.transform.position, FrustumPoint2.transform.position, FrustumPointBase.transform.position);
        planoFront = new Plane(FrustumBase3.transform.position, FrustumBase1.transform.position);


        planoTop.Flip();
        planoFront.Flip();
        planoBottom.Flip();




    }

    // Update is called once per frame
    void Update()
    {
        planoBottom = new Plane(FrustumPoint3.transform.position, FrustumPoint2.transform.position, FrustumPointBase.transform.position);
        planoTop = new Plane(FrustumPoint1.transform.position, FrustumPoint4.transform.position, FrustumPointBase.transform.position);
        planoBack = new Plane(FrustumPoint3.transform.position, FrustumPoint1.transform.position);
        planoLeft = new Plane(FrustumPoint3.transform.position, FrustumPoint4.transform.position, FrustumPointBase.transform.position);
        planoRight = new Plane(FrustumPoint1.transform.position, FrustumPoint2.transform.position, FrustumPointBase.transform.position);
        planoFront = new Plane(FrustumBase3.transform.position, FrustumBase1.transform.position);
        planoTop.Flip();
        planoFront.Flip();
        planoBottom.Flip();

        Debug.DrawLine(FrustumPoint1.transform.position, FrustumPoint2.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint1.transform.position, FrustumPoint4.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint2.transform.position, FrustumPoint3.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint3.transform.position, FrustumPoint4.transform.position, Color.green);

        Debug.DrawLine(FrustumPoint1.transform.position, FrustumBase1.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint2.transform.position, FrustumBase2.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint3.transform.position, FrustumBase3.transform.position, Color.green);
        Debug.DrawLine(FrustumPoint4.transform.position, FrustumBase4.transform.position, Color.green);

        Debug.DrawLine(FrustumBase1.transform.position, FrustumBase2.transform.position, Color.green);
        Debug.DrawLine(FrustumBase1.transform.position, FrustumBase4.transform.position, Color.green);
        Debug.DrawLine(FrustumBase3.transform.position, FrustumBase2.transform.position, Color.green);
        Debug.DrawLine(FrustumBase3.transform.position, FrustumBase4.transform.position, Color.green);


        for (int i = 0; i < InGameObjects.Length; i++)
        {
            if(planoBottom.GetSide(InGameObjects[i].transform.position) == true &&
               planoTop.GetSide(InGameObjects[i].transform.position) == true &&
               planoBack.GetSide(InGameObjects[i].transform.position) == true &&
               planoLeft.GetSide(InGameObjects[i].transform.position) == true &&
               planoFront.GetSide(InGameObjects[i].transform.position) == true &&
               planoRight.GetSide(InGameObjects[i].transform.position) == true
               )
            {
                InGameObjects[i].GetComponent<MeshRenderer>().enabled = true;
            }
            else 
            {
                InGameObjects[i].GetComponent<MeshRenderer>().enabled = false;
            }

        }


    }
}
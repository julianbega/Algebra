/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CustomMath;

public class FrustumCooler : MonoBehaviour
{
    Vec3 point0 = new Vec3(0.0f, 14.0f, 0.0f);
    Vec3 point1 = new Vec3(-1.0f, 15.0f, 0.0f);
    Vec3 point2 = new Vec3(-1.0f, 13.0f, 0.0f);
    Vec3 point3 = new Vec3(1.0f, 13.0f, 0.0f);
    Vec3 point4 = new Vec3(1.0f, 15.0f, 0.0f);
    Vec3 point5 = new Vec3(-150.0f, 300.0f, 500.0f);
    Vec3 point6 = new Vec3(-150.0f, -100.0f, 500.0f);
    Vec3 point7 = new Vec3(150.0f, -100.0f, 500.0f);
    Vec3 point8 = new Vec3(150.0f, 300.0f, 500.0f);

    Vec3 pointToTestInside = new Vec3(2.5f, 2.5f, 2.5f);

    Plano planoBottom;
    Plano planoTop;
    Plano planoFront;
    Plano planoBack;
    Plano planoLeft;
    Plano planoRight;

    Plane planeBottom;
    Plane planeTop;
    Plane planeFront;
    Plane planeBack;
    Plane planeLeft;
    Plane planeRight;

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
        Vec3 FrustP1 = new Vec3(FrustumPoint1.transform.position.x, FrustumPoint1.transform.position.y, FrustumPoint1.transform.position.z);
        Vec3 FrustP2 = new Vec3(FrustumPoint2.transform.position.x, FrustumPoint2.transform.position.y, FrustumPoint2.transform.position.z);
        Vec3 FrustP3 = new Vec3(FrustumPoint3.transform.position.x, FrustumPoint3.transform.position.y, FrustumPoint3.transform.position.z);
        Vec3 FrustP4 = new Vec3(FrustumPoint4.transform.position.x, FrustumPoint4.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB = new Vec3(FrustumPointBase.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB1 = new Vec3(FrustumBase1.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB3= new Vec3(FrustumBase3.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);
        planoBottom = new Plano(FrustP3, FrustP2, FrustPB);
        planoTop = new Plano(FrustP1, FrustP4, FrustPB);
        planoBack = new Plano(FrustP3, FrustP1);
        planoRight = new Plano(FrustP3, FrustP4, FrustPB);
        planoLeft = new Plano(FrustP1, FrustP2, FrustPB);
        planoFront = new Plano(FrustPB1, FrustPB3);

        planoBack.Flip();
        planoFront.Flip();
        planoLeft.Flip();
        planoRight.Flip();

        //////////////////////////////////////////////////////
        planeBottom = new Plane(FrustP3, FrustP2, FrustPB);
        planeTop = new Plane(FrustP1, FrustP4, FrustPB);
        planeBack = new Plane(FrustP3, FrustP1);
        planeRight = new Plane(FrustP3, FrustP4, FrustPB);
        planeLeft = new Plane(FrustP1, FrustP2, FrustPB);
        planeFront = new Plane(FrustPB1, FrustPB3);
        planeFront.Flip();
        planeLeft.Flip();
        planeRight.Flip();
        //////////////////////////////////////////////////////
    }

    // Update is called once per frame
    void Update()
    {
        Vec3 FrustP1 = new Vec3(FrustumPoint1.transform.position.x, FrustumPoint1.transform.position.y, FrustumPoint1.transform.position.z);
        Vec3 FrustP2 = new Vec3(FrustumPoint2.transform.position.x, FrustumPoint2.transform.position.y, FrustumPoint2.transform.position.z);
        Vec3 FrustP3 = new Vec3(FrustumPoint3.transform.position.x, FrustumPoint3.transform.position.y, FrustumPoint3.transform.position.z);
        Vec3 FrustP4 = new Vec3(FrustumPoint4.transform.position.x, FrustumPoint4.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB = new Vec3(FrustumPointBase.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB1 = new Vec3(FrustumBase1.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);
        Vec3 FrustPB3 = new Vec3(FrustumBase3.transform.position.x, FrustumPointBase.transform.position.y, FrustumPoint4.transform.position.z);



        planoBottom = new Plano(FrustP3, FrustP2, FrustPB);
        planoTop = new Plano(FrustP1, FrustP4, FrustPB);
        planoBack = new Plano(FrustP3, FrustP1);
        planoRight= new Plano(FrustP3, FrustP4, FrustPB);
        planoLeft = new Plano(FrustP1, FrustP2, FrustPB);
        planoFront = new Plano(FrustPB1, FrustPB3);

        planoRight.Flip();

        ////////////////////////////////////////////////
        planeBottom = new Plane(FrustP3, FrustP2, FrustPB);
        planeTop = new Plane(FrustP1, FrustP4, FrustPB);
        planeBack = new Plane(FrustP3, FrustP1);
        planeRight = new Plane(FrustP3, FrustP4, FrustPB);
        planeLeft = new Plane(FrustP1, FrustP2, FrustPB);
        planeFront = new Plane(FrustPB1, FrustPB3);

        planeFront.Flip();
        planeRight.Flip();
        planeLeft.Flip();
        ////////////////////////////////////////////////////

        DrawPlaneAtPoint(planeRight, new Vector3(0,0,0), 10, Color.green , 10 , true);
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
            Vec3 iGameObjetPos = new Vec3(InGameObjects[i].transform.position.x, InGameObjects[i].transform.position.y, InGameObjects[i].transform.position.z);

            
            Debug.Log("planoBottom side in cube " + i + " is " + planeBottom.GetSide(iGameObjetPos));
            Debug.Log("planoTop side in cube " + i + " is " + planeTop.GetSide(iGameObjetPos));
            Debug.Log("planoBack side in cube " + i + " is " + planeBack.GetSide(iGameObjetPos));
            Debug.Log("planoLeft side in cube " + i + " is " + planeLeft.GetSide(iGameObjetPos));
            Debug.Log("planoFront side in cube " + i + " is " + planeFront.GetSide(iGameObjetPos));
            Debug.Log("planoRight side in cube " + i + " is " + planeRight.GetSide(iGameObjetPos));

            Debug.Log("planeRight side in cube " + i + " is " + planeRight.GetDistanceToPoint(iGameObjetPos));

            Debug.Log("planoRight side in cube " + i + " is " + planoRight.GetDistanceToPoint(iGameObjetPos));

            if (planeBottom.GetSide(iGameObjetPos) == true &&
               planeTop.GetSide(iGameObjetPos) == true &&
               planeBack.GetSide(iGameObjetPos) == true &&
               planeLeft.GetSide(iGameObjetPos) == true &&
               planeFront.GetSide(iGameObjetPos) == true &&
               planeRight.GetSide(iGameObjetPos) == true
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

    static void DrawPlaneAtPoint(Plane plane, Vector3 center, float size, Color color, float duration, bool depthTest)
    {
        var basis = Quaternion.LookRotation(plane.normal);
        var scale = Vector3.one * size / 10f;

        var right = Vector3.Scale(basis * Vector3.right, scale);
        var up = Vector3.Scale(basis * Vector3.up, scale);

        for (int i = -5; i <= 5; i++)
        {
            Debug.DrawLine(center + right * i - up * 5, center + right * i + up * 5, color, duration, depthTest);
            Debug.DrawLine(center + up * i - right * 5, center + up * i + right * 5, color, duration, depthTest);
        }
    }
}*/

using UnityEngine;

public class FrustumCooler : MonoBehaviour
{
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
            Vector3 iGameObjetPos = new Vector3(InGameObjects[i].transform.position.x, InGameObjects[i].transform.position.y, InGameObjects[i].transform.position.z);
            Debug.Log("planoBottom side in cube " + i + " is " + planoBottom.GetSide(iGameObjetPos));
            Debug.Log("planoTop side in cube " + i + " is " + planoTop.GetSide(iGameObjetPos));
            Debug.Log("planoBack side in cube " + i + " is " + planoBack.GetSide(iGameObjetPos));
            Debug.Log("planoLeft side in cube " + i + " is " + planoLeft.GetSide(iGameObjetPos));
            Debug.Log("planoFront side in cube " + i + " is " + planoFront.GetSide(iGameObjetPos));
            Debug.Log("planoRight side in cube " + i + " is " + planoRight.GetSide(iGameObjetPos));


            if (planoBottom.GetSide(InGameObjects[i].transform.position) == true &&
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
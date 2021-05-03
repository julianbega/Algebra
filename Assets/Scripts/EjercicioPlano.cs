using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercicioPlano : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 point1 = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 point2 = new Vector3(5.0f, 0.0f, 0.0f);
    Vector3 point3 = new Vector3(0.0f, 0.0f, 5.0f);
    Vector3 point4 = new Vector3(5.0f, 0.0f, 5.0f);
    Vector3 point5 = new Vector3(0.0f, 5.0f, 0.0f);
    Vector3 point6 = new Vector3(5.0f, 5.0f, 0.0f);
    Vector3 point7 = new Vector3(0.0f, 5.0f, 5.0f);
    Vector3 point8 = new Vector3(5.0f, 5.0f, 5.0f);

    Vector3 pointToTestInside = new Vector3(2.5f, 2.5f, 2.5f);


    Plane planoBottom;
    Plane planoTop;
    Plane planoFront;
    Plane planoBack;
    Plane planoLeft;
    Plane planoRight;


    void Start()
    {
        planoBottom = new Plane(point1, point4);
        planoTop = new Plane(point5, point8);
        planoFront = new Plane(point1, point6);
        planoBack = new Plane(point3, point8);
        planoLeft = new Plane(point1, point7);
        planoRight = new Plane(point2, point8);

        if (planoBottom.GetSide(pointToTestInside) ==
            planoTop.GetSide(pointToTestInside) == 
            planoFront.GetSide(pointToTestInside) ==
            planoBack.GetSide(pointToTestInside) ==
            planoLeft.GetSide(pointToTestInside)==
            planoRight.GetSide(pointToTestInside))
        {
            Debug.Log("está adentro");
        }
        else 
        { Debug.Log("no está adentro"); }
    }

    // Update is called once per frame
    void Update()
    {
        if (planoBottom.GetSide(this.transform.position) ==
            planoTop.GetSide(this.transform.position) ==
            planoFront.GetSide(this.transform.position) ==
            planoBack.GetSide(this.transform.position) ==
            planoLeft.GetSide(this.transform.position) ==
            planoRight.GetSide(this.transform.position))
        {
            if (planoBottom.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x/2) &&
            planoTop.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x / 2) &&
            planoFront.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x / 2) &&
            planoBack.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x / 2) &&
            planoLeft.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x / 2) &&
            planoRight.GetDistanceToPoint(this.transform.position) >= (this.transform.localScale.x / 2))
            {
                Debug.Log("está adentro");
            }
            else
            {
                Debug.Log("hay parte adentro");
            }
        }
        else
        {
            Debug.Log("no está adentro");
        }

    }
}

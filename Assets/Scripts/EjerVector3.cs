//using EjerciciosAlgebra;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class EjerVector3 : MonoBehaviour
{

    enum Ejer
    {
        Uno, Dos,Tres,Cuatro,Cinco,Seis,Siete,Ocho,Nueve,Diez
    }
    [SerializeField] Ejer EjerActual;
    [SerializeField] Vec3 vectorA;
    [SerializeField] Vec3 vectorB;

    float timer = 0;
    Vec3 vectorC;
    void Start()
    {
        timer = 0;
        
        Vector3Debugger.AddVector(vectorA, "A");
        Vector3Debugger.AddVector(vectorB, "B");
        Vector3Debugger.AddVector(vectorC, "C");
        Vector3Debugger.UpdateColor("A", Color.white);
        Vector3Debugger.UpdateColor("B", Color.white);
        Vector3Debugger.EnableCoordinates();
        Vector3Debugger.EnableEditorView();
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (EjerActual)
        {
            case Ejer.Uno:
                vectorC = vectorA + vectorB;
                Debug.Log("vectorC: X" + vectorC.x + "|Y:" + vectorC.y + "|Z:" + vectorC.z);
                break;
            case Ejer.Dos:
                vectorC =  vectorB- vectorA;
                Debug.Log("vectorC: X" + vectorC.x + "|Y:" + vectorC.y + "|Z:" + vectorC.z);
                break;
            case Ejer.Tres:
                vectorC = new Vec3((vectorB.x * vectorA.x),(vectorB.y * vectorA.y) , (vectorB.z * vectorA.z));
                break;
            case Ejer.Cuatro:
                vectorC = new Vec3(
                    ((vectorB.y * vectorA.z) - (vectorB.z * vectorA.y)),
                    ((vectorB.z * vectorA.x) - (vectorB.x * vectorA.z)),
                    ((vectorB.x * vectorA.y) - (vectorB.y * vectorA.x)));
                break;
            case Ejer.Cinco:
                timer += Time.deltaTime;
                vectorC = Vec3.Lerp(vectorA, vectorB, timer);
                break;
            case Ejer.Seis:
                vectorC = Vec3.Max(vectorA, vectorB);
                break;
            case Ejer.Siete:
                vectorC = Vec3.Project(vectorA, vectorB);
                break;
            case Ejer.Ocho:

                break;
            case Ejer.Nueve:
                vectorC = Vec3.Reflect(vectorA, vectorB);
                break;
            case Ejer.Diez:
                timer += Time.deltaTime;
                vectorC = Vec3.LerpUnclamped(vectorB, vectorA, timer);
                break;
            default:
                break;
        }

        
        Vector3Debugger.UpdatePosition("A", vectorA);
        Vector3Debugger.UpdatePosition("B", vectorB);
        Vector3Debugger.UpdatePosition("C", vectorC);
    }
}

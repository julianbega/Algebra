using UnityEngine;
using CustomMath;
using MathDebbuger;
using System.Collections.Generic;

public class EjerQuaternions : MonoBehaviour
{
    enum Ejer
    {
        Uno = 1, Dos, Tres
    }
    [SerializeField] Ejer EjerActual;
    public float angle;

    private Vec3 vectors1;
    private List<Vector3> vectors2 = new List<Vector3>();
    private List<Vector3> vectors3 = new List<Vector3>();
    private void Start()
    {
        /*
        vectors1 = new Vec3(9, 0, 0);
        Vector3Debugger.AddVector(vectors1, Color.red, "vectors1");
        vectors2.Add(new Vec3(10, 0, 0));
        vectors2.Add(new Vec3(10, 10, 0));
        vectors2.Add(new Vec3(20, 10, 0));
        Vector3Debugger.AddVectorsSecuence(vectors2, false, Color.blue, "vectors2");*/

        vectors3.Add(new Vec3(10, 0, 0));
        vectors3.Add(new Vec3(10, 10, 0));
        vectors3.Add(new Vec3(20, 10, 0));
        vectors3.Add(new Vec3(20, 20, 0));
        Vector3Debugger.AddVectorsSecuence(vectors3, false, Color.yellow, "vectors3");

        Vector3Debugger.EnableCoordinates();
    }
    void FixedUpdate()
    {
        switch (EjerActual)
        {
            case Ejer.Uno:
                Vector3Debugger.UpdateColor("vectors3", Color.red);
                vectors3[0] = Quaternion.Euler(new Vector3(0, 0, angle)) * vectors3[0];
                Vector3Debugger.UpdatePosition("vectors3", vectors3[0]);
                //Vector3Debugger.DisableEditorView("vector2");
               // Vector3Debugger.DisableEditorView("vector3");
                //Vector3Debugger.DisableEditorView("vector4");
                Vector3Debugger.EnableEditorView("vectors3");
                break;
            case Ejer.Dos:
                /*
                Vector3Debugger.UpdateColor("vector1", Color.blue);
                Vector3Debugger.UpdateColor("vector2", Color.blue);
                Vector3Debugger.UpdateColor("vector3", Color.blue);
                vector1 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector1;
                vector2 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector2;
                vector3 = Quaternion.Euler(new Vector3(0, angle, 0)) * vector3;
                Vector3Debugger.UpdatePosition("vector1", vector1);
                Vector3Debugger.UpdatePosition("vector2", vector2);
                Vector3Debugger.UpdatePosition("vector3", vector3);
                Vector3Debugger.EnableEditorView("vector1");
                Vector3Debugger.EnableEditorView("vector2");
                Vector3Debugger.EnableEditorView("vector3");*/
                break;
            case Ejer.Tres:/*
                Vector3Debugger.UpdateColor("vector1", Color.yellow);
                Vector3Debugger.UpdateColor("vector2", Color.yellow);
                Vector3Debugger.UpdateColor("vector3", Color.yellow);
                Vector3Debugger.UpdateColor("vector4", Color.yellow);
                for (int i = 0; i < vectoresEjer3.Count; i++)
                {
                    if ((i % 2) != 0)
                    {
                        if (i == 3)
                            vectoresEjer3[i] = MyQuaternion.Euler(new Vec3(-Angle, -Angle, 0)) * new Vec3(vectoresEjer3[i]);
                        else
                            vectoresEjer3[i] = MyQuaternion.Euler(new Vec3(Angle, Angle, 0)) * new Vec3(vectoresEjer3[i]);
                    }
                }
                Matrix4x4 se = Matrix4x4.identity;
                VectorDebugger.DisableEditorView("vec");
                VectorDebugger.DisableEditorView("vectores");
                VectorDebugger.EnableEditorView("vectores2");
                VectorDebugger.UpdatePositionsSecuence("vectores2", vectoresEjer3);*/
                break;
        }
    }
}

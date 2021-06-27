using UnityEngine;
using CustomMath;
using MathDebbuger;
using System.Collections.Generic;

public class EjerQuaternions : MonoBehaviour
{
    enum Ejer
    {
        Uno, Dos, Tres
    }
    [SerializeField] Ejer EjerActual;
    public float angle;

    private Vec3 vectors1;

    private List<Vector3> vectors2 = new List<Vector3>();
    private List<Vector3> vectors3 = new List<Vector3>();
    private void Start()
    {
        vectors1 = new Vec3(9, 0, 0);
        Vector3Debugger.AddVector(vectors1, Color.red, "vector1");
        vectors2.Add(new Vec3(10, 0, 0));
        vectors2.Add(new Vec3(10, 10, 0));
        vectors2.Add(new Vec3(20, 10, 0));
        Vector3Debugger.AddVectorsSecuence(vectors2, false, Color.blue, "vectors2");

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
                vectors1 = Quaterniones.Euler(new Vec3(0, angle, 0)) * vectors1;

                Vector3Debugger.DisableEditorView("vectors2");
                Vector3Debugger.DisableEditorView("vectors3");

                Vector3Debugger.EnableEditorView("vector1");
                Vector3Debugger.UpdatePosition("vector1", vectors1);
                break;
            case Ejer.Dos:
                for (int i = 0; i < vectors2.Count; i++)
                {
                    vectors2[i] = Quaterniones.Euler(new Vec3(0, angle, 0)) * new Vec3(vectors2[i]);
                }

                Vector3Debugger.DisableEditorView("vectors3");
                Vector3Debugger.DisableEditorView("vector1");

                Vector3Debugger.EnableEditorView("vectors2");
                Vector3Debugger.UpdatePositionsSecuence("vectors2", vectors2);
                break;
            case Ejer.Tres:
                for (int i = 0; i < vectors3.Count; i++)
                {
                    if ((i % 2) != 0)
                    {
                        if (i == 3)
                            vectors3[i] = Quaterniones.Euler(new Vec3(-angle, -angle, 0)) * new Vec3(vectors3[i]);
                        else
                            vectors3[i] = Quaterniones.Euler(new Vec3(angle, angle, 0)) * new Vec3(vectors3[i]);
                    }
                }
                Matrix4x4 se = Matrix4x4.identity;
                Vector3Debugger.DisableEditorView("vector1");
                Vector3Debugger.DisableEditorView("vectors2");

                Vector3Debugger.EnableEditorView("vectors3");
                Vector3Debugger.UpdatePositionsSecuence("vectors3", vectors3);
                break;
        }
    }
}

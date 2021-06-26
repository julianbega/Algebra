using UnityEngine;
using CustomMath;
using MathDebbuger;

public class EjerQuaternions : MonoBehaviour
{
    enum Ejer
    {
        Uno, Dos, Tres
    }
    [SerializeField] Ejer EjerActual;
    public float angle;
    void Start()
    {
        switch (EjerActual)
        {
            case Ejer.Uno:
                break;
            case Ejer.Dos:
                break;
            case Ejer.Tres:

                break;

            default:
                break;
        }
    }
    void Update()
    {
        switch (EjerActual)
        {
            case Ejer.Uno:
                transform.position = Quaternion.Euler(new Vector3(0f, angle, 0f)) * transform.position;
                break;
            case Ejer.Dos:
                break;
            case Ejer.Tres:
                
                break;
            
            default:
                break;
        }
    }
}

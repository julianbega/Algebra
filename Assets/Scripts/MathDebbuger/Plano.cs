using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using System;
using System.Drawing;
using UnityEditor;

namespace CustomMath
{
    public struct Plano
    {
        public Plano(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = Mathf.Abs(Vec3.Dot(normal, inPoint)) / Vector3.Magnitude(normal);

        }

        public Plano(Vec3 a, Vec3 b, Vec3 c) 
        {
            Vec3 side1 = b - a;
            Vec3 side2 = c - a;

            normal = Vec3.Cross(side1, side2).normalized;

            distance = -Vec3.Dot(normal, a) / Vector3.Magnitude(normal); ;
        }
        public Vec3 normal { get; set; }
        public float distance { get; set; }
        public Plano flipped
        {
            get
            {
                return new Plano(-normal, -normal * distance);
            }
        }

        public static Plano Translate(Plano plano, Vec3 translation)
        {
            Vec3 aux = -(plano.normal * plano.distance + translation);
            return new Plano(plano.normal, aux);
        }
        public Vec3 ClosestPointOnPlane(Vec3 point)
        { 
            return (point - normal * GetDistanceToPoint(point)); 
        }
        public void Flip()
        {
            normal = -normal;
            distance = -distance;
        }
        public float GetDistanceToPoint(Vec3 point)
        {
            return Vec3.Dot(normal, point) + distance;
        }
        public bool GetSide(Vec3 point)
        {
            float tempDistance = GetDistanceToPoint(point);

            return (tempDistance > 0);                     
        }
        public bool SameSide(Vec3 inPt0, Vec3 inPt1)
        {

            if (GetSide(inPt0) == true && GetSide(inPt1) == true)
            {
                return true;
            }
            else return false;
            
        }
        public void Set3Points(Vec3 a, Vec3 b, Vec3 c)
        {
            Vec3 side1 = b - a;
            Vec3 side2 = c - a;

            normal = Vec3.Cross(side1, side2).normalized;

            distance = -Vec3.Dot(normal, a) / normal.magnitude; ;
        }
        public void SetNormalAndPosition(Vec3 inNormal, Vec3 inPoint)
        {
            normal = inNormal.normalized;
            distance = -Vec3.Dot(inNormal, inPoint);
        }
        public override string ToString()
        { 
            return "(normal:(" + normal.x + ", " + normal.y + ", " + normal.z + "), distance:" + distance + ")";
        }
      /*  public string ToString(string format)
        { }*/
        public void Translate(Vec3 translation)
        {
            Vec3 aux = (normal * distance + translation);
            distance = Vec3.Dot(normal, aux);
        }
    }
}

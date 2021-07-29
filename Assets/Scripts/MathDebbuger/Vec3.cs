using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude 
        { 
            get 
            { 
                return (x * x + y * y + z * z); 
            } 
        }
        public Vec3 normalized { 
            get 
            { 
                return new Vec3(x / magnitude, y / magnitude, z / magnitude); 
            } 
        }
        public float magnitude
        { 
            get
            { 
                return Mathf.Sqrt(sqrMagnitude);  
            } 
        }
        #endregion

        #region constants
        public const float epsilon = 1e-05f;
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            if(left.x == right.x && left.y == right.y && left.z == right.z )
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x - rightV3.x, leftV3.y - rightV3.y, leftV3.z - rightV3.z);
        }

        public static Vec3 operator -(Vec3 v3)
        {
            return new Vec3(Zero - v3);
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }
        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            return new Vec3(v3.x * scalar, v3.y * scalar, v3.z * scalar);
        }
        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            return new Vec3(v3.x / scalar, v3.y / scalar, v3.z / scalar);
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            return new Vector2(v2.x, v2.y);
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            // la formula es cos del angulo = a (from * to)/ (magnitud de from * magnitud de to), por lo que angulo = arcos de [(from * to)/ (magnitud de from * magnitud de to)]
            float result = (from.x * to.x) + (from.y * to.y) + (from.z * to.z);
            float a = Mathf.Sqrt(from.x + from.y + from.z);
            float b = Mathf.Sqrt(to.x + to.y + to.z);
            return Mathf.Acos(result / (a * b));
        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {
            if (Magnitude(vector) > maxLength)
                return vector.normalized * maxLength;           
            else
                return vector;
        }
        public static float Magnitude(Vec3 vector)
        {
            return vector.magnitude;
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
        // Devuelve un vector en el medio entre a y b
        // https://docs.unity3d.com/ScriptReference/Vector3.Cross.html
            return new Vec3((a.y * b.z) - (b.y * a.z), (a.z * b.x) - (b.z * a.x), (a.x * b.y) - (b.x * a.y));
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
        // https://www.varsitytutors.com/calculus_3-help/distance-between-vectors
            return (float)Math.Sqrt(((b.x - a.x) * (b.x - a.x)) + ((b.y - a.y) * (b.y - a.y)) + ((b.z - a.z) * (b.z - a.z)));
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            //For normalized vectors Dot returns 1 if they point in exactly the same direction, -1 if they point in completely opposite directions and zero if the vectors are perpendicular.
            //podes saber el tipo de angulo entre 2 vectors
            //https://byjus.com/maths/dot-product-of-two-vectors/
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {       
            Vec3 newVec = Vec3.One;
            if (t < 1)
            {
                newVec = new Vec3(((b - a) * t + a));
            }
            else
            {
                t = 1.0f;
                newVec = new Vec3(((b - a) * t + a));
            }
            return newVec;
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            return a + new Vec3((b - a) * t);
        }
        public static Vec3 Max(Vec3 a, Vec3 b)
        {
            float maxX = a.x;
            float maxY = a.y;
            float maxZ = a.z;
            if (maxX < b.x) maxX = b.x;
            if (maxY < b.y) maxY = b.y;
            if (maxZ < b.z) maxZ = b.z;

            return new Vec3(maxX, maxY, maxZ);
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            float minX = a.x;
            float minY = a.y;
            float minZ = a.z;
            if (minX > b.x) minX = b.x;
            if (minY > b.y) minY = b.y;
            if (minZ > b.z) minZ = b.z;

            return new Vec3(minX, minY, minZ);
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return vector.sqrMagnitude;
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal)
        {
            // la normal es para donde apunta el plano y el vecor que da la direccion a nuestro vector resultado
            // vector es el que determina el resultado de la projection (vector resultado), ya que es la normal escalada para que su "punta" sea el punto más cercano a la "punta" del vector 
            return (Dot(vector, onNormal) / Mathf.Pow(Magnitude(onNormal), 2) * onNormal);
        }
        /*{
           return (Vec3.Dot(vector, onNormal) /((Magnitude(onNormal)* Magnitude(onNormal)) * onNormal));
        }*/
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal) 
        {
            // la normal es para donde apunta el plano, un vector perpendicular a la superficie, 
            // inDirection es un vector que se dirije al plano, la funcion devuelve un vector con la misma magnitud paro como si hubiese rebotado en el plano
            inNormal.Normalize();
            return inDirection - 2 * (-Dot(inDirection, inNormal)) * inNormal;
        }
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public void Scale(Vec3 scale)
        {
            Set(x * scale.x, y * scale.y, z * scale.z);
        }
        public void Normalize()
        {
            Set(normalized.x, normalized.y, normalized.z);
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}
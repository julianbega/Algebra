using UnityEngine;
using System;
using UnityEngine.Internal;

namespace CustomMath
{
    public struct Quaterniones
    {
        /// pasar todo a ingles
        ///  https://github.com/NickCuso/Tutorials/blob/master/Quaternions.md

        //https://eater.net/quaternions
        //https://www.youtube.com/playlist?list=PLP1RASvNhZXikttHjjER8Pp7pP33wQUJC (algunos)

        public const float kEpsilon = 1E-06F;
        public float x;
        public float y;
        public float z;
        public float w;

        //Constructors   ez
        public Quaterniones(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public Quaterniones(Quaternion q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }
        public Quaterniones(Quaterniones q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }




        //Static Properties        ez 
            public static Quaterniones identity
        {
            get
            {
                return new Quaterniones(0.0f, 0.0f, 0.0f, 1.0f);
            }
        }

        //Properties    ez
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Fuera de rango (0-3)");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Fuera de rango (0-3)");
                }
            }
        }
       /*Chequear Euler*/ public Vec3 eulerAngles
        {
            get
            {
                Vec3 qAsVec3;

                qAsVec3.x = Mathf.Rad2Deg * Mathf.Asin(x * 2);
                qAsVec3.y = Mathf.Rad2Deg * Mathf.Asin(y * 2);
                qAsVec3.z = Mathf.Rad2Deg * Mathf.Asin(z * 2);
                /// falta W

                return qAsVec3;
            }
            set
            {
                Quaterniones q = Euler(value);
                x = q.x;
                y = q.y;
                z = q.z;
                w = q.w;

            }
        }
        public Quaterniones normalize
        {
            get
            {
                float mag = Mathf.Sqrt(x * x + y * y + z * z + w * w);
                Quaternion q = new Quaternion(x / mag, y / mag, z / mag, w / mag);
                return new Quaterniones(q.x, q.y, q.z, q.w);
            }
        }

        ///Public Methods
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }
      
        public void SetFromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Quaterniones q = FromToRotation(fromDirection, toDirection);
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;

        }
       
        public void SetLookRotation(Vec3 view, [DefaultValue("Vector3.up")] Vec3 up)
        {
            Quaterniones q = LookRotation(view, up);
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }

        public void SetLookRotation(Vec3 view)
        {
            Quaterniones q = LookRotation(view);
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
        }  
        public override string ToString()
        {
            return ("X = " + x + ", Y = " + y + ", Z = " + z + ", W = " + w);
        }

        // Static Methods
        public static float Angle(Quaterniones a, Quaterniones b)
        {
            Quaterniones inv = Inverse(a);
            Quaterniones result = b * inv;

            float angle = Mathf.Acos(result.w) * 2.0f * Mathf.Rad2Deg;
            return angle;
        }
        
        public static Quaterniones AngleAxis(float angle, Vector3 axis)
        {
            angle *= Mathf.Deg2Rad * 0.5f;
            axis.Normalize();
            Quaterniones newQ;
            newQ.x = axis.x * Mathf.Sin(angle);
            newQ.y = axis.y * Mathf.Sin(angle);
            newQ.z = axis.z * Mathf.Sin(angle);
            newQ.w = Mathf.Cos(angle);
            return newQ.normalize;
            /// https://www.youtube.com/watch?v=B58A1qkEkik&ab_channel=huse360
        }

        public static float Dot(Quaterniones a, Quaterniones b)
        {
            return ((a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w));
        }

      
        public static Quaterniones Euler(Vec3 euler)
        {
            Quaterniones qX = identity;
            Quaterniones qY = identity;
            Quaterniones qZ = identity;

            float sin = Mathf.Sin(Mathf.Deg2Rad * euler.x * 0.5f);
            float cos = Mathf.Cos(Mathf.Deg2Rad * euler.x * 0.5f);
            qX.Set(sin, 0.0f, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.y * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.y * 0.5f);
            qY.Set(0.0f, sin, 0.0f, cos);

            sin = Mathf.Sin(Mathf.Deg2Rad * euler.z * 0.5f);
            cos = Mathf.Cos(Mathf.Deg2Rad * euler.z * 0.5f);
            qZ.Set(0.0f, 0.0f, sin, cos);

            return new Quaterniones(qX * qY * qZ);
            /// https://www.youtube.com/watch?v=B58A1qkEkik&ab_channel=huse360
        }
        public static Quaterniones Euler(float x, float y, float z)
        {
            return Euler(new Vec3(x, y, z));
        }


        public static Quaterniones FromToRotation(Vec3 fromDirection, Vec3 toDirection)
        {
            Vec3 cross = Vec3.Cross(fromDirection, toDirection);
            Quaterniones q;
            q.x = cross.x;
            q.y = cross.y;
            q.z = cross.z;
            q.w = fromDirection.magnitude * toDirection.magnitude + Vec3.Dot(fromDirection, toDirection);
            q.Normalize();
            return q;

           // https://www.youtube.com/watch?v=jTgdKoQv738&ab_channel=PenguinMaths
           // Creates a rotation which rotates from fromDirection to toDirection.
           //Usually you use this to rotate a transform so that one of its axes eg.the y-axis - follows a target direction toDirection in world space.
        }
       
       
        public static Quaterniones Inverse(Quaterniones rotation)
        {
            return new Quaterniones(-rotation.x, -rotation.y, -rotation.z, rotation.w);
        }
      
        public static Quaterniones Lerp(Quaterniones a, Quaterniones b, float t)
        {
            t = Mathf.Clamp(t, 0, 1);  // reduce el float a 1 en caso de ser necesario para que el lerp sea fluido
            return LerpUnclamped(a, b, t);
        }
             
        public static Quaterniones LerpUnclamped(Quaterniones a, Quaterniones b, float t)
        {
            Quaterniones difference = new Quaterniones(b.x - a.x, b.y - a.y, b.z - a.z, b.w - b.w);
            Quaterniones differenceLerped = new Quaterniones(difference.x * t, difference.y * t, difference.z * t, difference.w * t);

            return new Quaterniones(a.x + differenceLerped.x, a.y + differenceLerped.y, a.z + differenceLerped.z, a.w + differenceLerped.w).normalize;
        }
        //Interpolates between a and b by t and normalizes the result afterwards.

        public static Quaterniones LookRotation(Vec3 forward)
        {
            return LookRotation(forward, Vec3.Up);
        }
        public static Quaterniones LookRotation(Vec3 forward, Vec3 upwards)
        {
            Quaterniones result;
            if (forward == Vec3.Zero || upwards == Vec3.Zero || (forward.normalized == upwards.normalized) )
            {
                result = Quaterniones.identity;
                return result;
            }
            else
            {
                upwards.Normalize();
                Vec3 a = forward + upwards -Vec3.Cross(forward, upwards);
                Quaterniones q = Quaterniones.FromToRotation(Vec3.Forward, a);
                return Quaterniones.FromToRotation(a, forward) * q;
            }
        }

        public static Quaterniones Normalize(Quaterniones q)
        {
            return new Quaterniones(q.normalize);
        }

       
        public static Quaterniones Slerp(Quaterniones a, Quaterniones b, float t)
        {
            /// reciclar
            t = Mathf.Clamp(t, 0, 1); 
            float num1;
            float num2;
            Quaterniones quaternion;
            float dot = (((a.x * b.x) + (a.y * b.y)) + (a.z * b.z)) + (a.w * b.w);
            bool neg = false;
            if (dot < 0f)
            {
                neg = true;
                dot = -dot;
            }
            if (dot >= 1.0f)
            {
                num1 = 1.0f - t;
                if (neg) num2 = -t;
                else num2 = t;
            }
            else
            {
                float num3 = (float)Math.Acos(dot);
                float num4 = (float)(1.0 / Math.Sin(num3));
                num1 = ((float)Math.Sin(((1f - t) * num3))) * num4;
                if (neg)
                    num2 = (((float)-Math.Sin((t * num3))) * num4);
                else
                    num2 = (((float)Math.Sin((t * num3))) * num4);
            }
            quaternion.x = ((num1 * a.x) + (num2 * b.x));
            quaternion.y = ((num1 * a.y) + (num2 * b.y));
            quaternion.z = ((num1 * a.z) + (num2 * b.z));
            quaternion.w = ((num1 * a.w) + (num2 * b.w));
            return quaternion;
        }
        public static Quaterniones SlerpUnclamped(Quaterniones a, Quaterniones b, float t)
        {
            float num1;
            float num2;
            Quaterniones quaternion;
            float dot = (((a.x * b.x) + (a.y * b.y)) + (a.z * b.z)) + (a.w * b.w);
            bool neg = false;
            if (dot < 0f)
            {
                neg = true;
                dot = -dot;
            }
            if (dot >= 1.0f)
            {
                num1 = 1.0f - t;
                if (neg) num2 = -t;
                else num2 = t;
            }
            else
            {
                float num3 = (float)Math.Acos(dot);
                float num4 = (float)(1.0 / Math.Sin(num3));
                num1 = ((float)Math.Sin(((1f - t) * num3))) * num4;
                if (neg)
                    num2 = (((float)-Math.Sin((t * num3))) * num4);
                else
                    num2 = (((float)Math.Sin((t * num3))) * num4);
            }
            quaternion.x = ((num1 * a.x) + (num2 * b.x));
            quaternion.y = ((num1 * a.y) + (num2 * b.y));
            quaternion.z = ((num1 * a.z) + (num2 * b.z));
            quaternion.w = ((num1 * a.w) + (num2 * b.w));
            return quaternion;
        }
        public void Normalize()
        {
            Quaterniones normalQ = new Quaterniones(normalize);
            x = normalQ.x;
            y = normalQ.y;
            z = normalQ.z;
            w = normalQ.w;
        }


        ///Operators
        public static Vec3 operator *(Quaterniones rotation, Vec3 point)
        {
            float num = rotation.x * 2f;
            float num2 = rotation.y * 2f;
            float num3 = rotation.z * 2f;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            Vec3 result;
            result.x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
            return result;

        }
        public static Quaterniones operator *(Quaterniones a, Quaterniones b)
        {
            float x = (a.w * b.x) + (a.x * b.w) + (a.y * b.z) - (a.z * b.y);
            float y = (a.w * b.y) - (a.x * b.z) + (a.y * b.w) + (a.z * b.x);
            float z = (a.w * b.z) + (a.x * b.y) - (a.y * b.x) + (a.z * b.w);
            float w = (a.w * b.w) - (a.x * b.x) - (a.y * b.y) - (a.z * b.z);
            return new Quaterniones(x, y, z, w);

            //https://www.youtube.com/watch?v=91YU5BV5s30&ab_channel=SamuelChung
        }
        public static bool operator ==(Quaterniones lhs, Quaterniones rhs)
        {
            return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w);
        }
        public static bool operator !=(Quaterniones lhs, Quaterniones rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Quaternion(Quaterniones q)
        {
            return new Quaternion(q.x, q.y, q.z, q.w);
        }

    }
}
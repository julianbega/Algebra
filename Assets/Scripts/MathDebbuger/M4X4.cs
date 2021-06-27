
using UnityEngine;


namespace CustomMath
{
    /*
    m00, m01, m02, m03
    m10, m11, m12, m13
    m20, m21, m22, m23
    m30, m31, m32, m33              
    */
    public struct M4X4
    {
        public float m00;
        public float m33;
        public float m23;
        public float m13;
        public float m03;
        public float m32;
        public float m22;
        public float m02;
        public float m12;
        public float m21;
        public float m11;
        public float m01;
        public float m30;
        public float m20;
        public float m10;
        public float m31;

        public M4X4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3)
        {
            m00 = column0.x;
            m01 = column1.x;
            m02 = column2.x;
            m03 = column3.x;
            m10 = column0.y;
            m11 = column1.y;
            m12 = column2.y;
            m13 = column3.y;
            m20 = column0.z;
            m21 = column1.z;
            m22 = column2.z;
            m23 = column3.z;
            m30 = column0.w;
            m31 = column1.w;
            m32 = column2.w;
            m33 = column3.w;
        }

        public static M4X4 zero
        {
            get
            {
                return new M4X4(
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f),
                    new Vector4(0f, 0f, 0f, 0f)
                    );
            }
        }       
        public static M4X4 identity
        {
            get
            {
                return new M4X4(
                    new Vector4(1f, 0f, 0f, 0f),
                    new Vector4(0f, 1f, 0f, 0f),
                    new Vector4(0f, 0f, 1f, 0f),
                    new Vector4(0f, 0f, 0f, 1f));
            }
        }

        public float this[int index]
        {
            get 
            {
                float matrixPos = -1;
                switch (index)
                {
                    case 0: 
                        return m00;
                    case 1:
                        return m01;
                    case 2:
                        return m02;
                    case 3:
                        return m03;
                    case 4:
                        return m10;
                    case 5:
                        return m11;
                    case 6:
                        return m12;
                    case 7:
                        return m13;
                    case 8:
                        return m20;
                    case 9:
                        return m21;
                    case 10:
                        return m22;
                    case 11:
                        return m23;
                    case 12:
                        return m30;
                    case 13:
                        return m31;
                    case 14:
                        return m32;
                    case 15:
                        return m33;
                    default:
                        break;
                }
                return matrixPos;
            }
        }

        public static M4X4 Rotate(Quaternion q)
        {
            M4X4 mRot = identity;
            mRot.m00 = 1 - 2.0f * (q.y * q.y) - 2.0f * (q.z * q.z);
            mRot.m01 = 2.0f * (q.x * q.y) - 2.0f * (q.z * q.w);
            mRot.m02 = 2.0f * (q.x * q.z) + 2.0f * (q.y * q.w);
            mRot.m10 = 2.0f * (q.x * q.y) + 2.0f * (q.z * q.w);
            mRot.m11 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.z * q.z);
            mRot.m12 = 2.0f * (q.y * q.z) - 2.0f * (q.x * q.w);
            mRot.m20 = 2.0f * (q.x * q.z) - 2.0f * (q.y * q.w);
            mRot.m21 = 2.0f * (q.y * q.z) + 2.0f * (q.x * q.w);
            mRot.m22 = 1 - 2.0f * (q.x * q.x) - 2.0f * (q.y * q.y);

            return mRot;
        }
        public static M4X4 Scale(Vec3 vector)
        {
            M4X4 mScale = zero;

            mScale.m00 = vector.x;
            mScale.m11 = vector.y;
            mScale.m22 = vector.z;
            mScale.m33 = 1.0f;

            return mScale;
        }
        public static M4X4 Translate(Vec3 vector)
        {
            M4X4 mTrans = identity;
            mTrans.m03 = vector.x;
            mTrans.m13 = vector.y;
            mTrans.m23 = vector.z;
            mTrans.m33 = 1.0f;

            return mTrans;
        }
        public static M4X4 TRS(Vec3 pos, Quaternion q, Vec3 s)
        {
            M4X4 matTrans = Translate(pos);
            M4X4 matRot = Rotate(q);
            M4X4 matScale = Scale(s);
            M4X4 trs = matTrans * matRot * matScale;
            return trs;
        }
        public override string ToString()
        {
            return (
            "m00  " + m00 +
            "  m01  " + m01 +
            "  m02  " + m02 +
            "  m03  " + m03 +
            "\nm10  " + m10 +
            "  m11  " + m11 +
            "  m12  " + m12 +
            "  m13  " + m13 +
            "\nm20  " + m20 +
            "  m21  " + m21 +
            "  m22  " + m22 +
            "  m23  " + m23 +
            "\nm30  " + m30 +
            "  m31  " + m31 +
            "  m32  " + m32 +
            "  m33  " + m33);
        }

        public static M4X4 operator *(M4X4 lhs, M4X4 rhs)
        {
            M4X4 matXMat = zero;
            matXMat.m00 = (lhs.m00 * rhs.m00) + (lhs.m01 * rhs.m10) + (lhs.m02 * rhs.m20) + (lhs.m03 * rhs.m30);
            matXMat.m01 = (lhs.m00 * rhs.m01) + (lhs.m01 * rhs.m11) + (lhs.m02 * rhs.m21) + (lhs.m03 * rhs.m31);
            matXMat.m02 = (lhs.m00 * rhs.m02) + (lhs.m01 * rhs.m12) + (lhs.m02 * rhs.m22) + (lhs.m03 * rhs.m32);
            matXMat.m03 = (lhs.m00 * rhs.m03) + (lhs.m01 * rhs.m13) + (lhs.m02 * rhs.m23) + (lhs.m03 * rhs.m33);

            matXMat.m10 = (lhs.m10 * rhs.m00) + (lhs.m11 * rhs.m10) + (lhs.m12 * rhs.m20) + (lhs.m13 * rhs.m30);
            matXMat.m11 = (lhs.m10 * rhs.m01) + (lhs.m11 * rhs.m11) + (lhs.m12 * rhs.m21) + (lhs.m13 * rhs.m31);
            matXMat.m12 = (lhs.m10 * rhs.m02) + (lhs.m11 * rhs.m12) + (lhs.m12 * rhs.m22) + (lhs.m13 * rhs.m32);
            matXMat.m13 = (lhs.m10 * rhs.m03) + (lhs.m11 * rhs.m13) + (lhs.m12 * rhs.m23) + (lhs.m13 * rhs.m33);

            matXMat.m20 = (lhs.m20 * rhs.m00) + (lhs.m21 * rhs.m10) + (lhs.m22 * rhs.m20) + (lhs.m23 * rhs.m30);
            matXMat.m21 = (lhs.m20 * rhs.m01) + (lhs.m21 * rhs.m11) + (lhs.m22 * rhs.m21) + (lhs.m23 * rhs.m31);
            matXMat.m22 = (lhs.m20 * rhs.m02) + (lhs.m21 * rhs.m12) + (lhs.m22 * rhs.m22) + (lhs.m23 * rhs.m32);
            matXMat.m23 = (lhs.m20 * rhs.m03) + (lhs.m21 * rhs.m13) + (lhs.m22 * rhs.m23) + (lhs.m23 * rhs.m33);

            matXMat.m30 = (lhs.m30 * rhs.m00) + (lhs.m31 * rhs.m10) + (lhs.m32 * rhs.m20) + (lhs.m33 * rhs.m30);
            matXMat.m31 = (lhs.m30 * rhs.m01) + (lhs.m31 * rhs.m11) + (lhs.m32 * rhs.m21) + (lhs.m33 * rhs.m31);
            matXMat.m32 = (lhs.m30 * rhs.m02) + (lhs.m31 * rhs.m12) + (lhs.m32 * rhs.m22) + (lhs.m33 * rhs.m32);
            matXMat.m33 = (lhs.m30 * rhs.m03) + (lhs.m31 * rhs.m13) + (lhs.m32 * rhs.m23) + (lhs.m33 * rhs.m33);
            return matXMat;
        }
        public static bool operator ==(M4X4 lhs, M4X4 rhs)
        {
            return (lhs.m00 == rhs.m00 && lhs.m01 == rhs.m01 && lhs.m02 == rhs.m02 && lhs.m03 == rhs.m03 &&
                lhs.m10 == rhs.m10 && lhs.m11 == rhs.m11 && lhs.m12 == rhs.m12 && lhs.m13 == rhs.m13 &&
                lhs.m20 == rhs.m20 && lhs.m21 == rhs.m21 && lhs.m22 == rhs.m22 && lhs.m23 == rhs.m23 &&
                lhs.m30 == rhs.m30 && lhs.m31 == rhs.m31 && lhs.m32 == rhs.m32 && lhs.m33 == rhs.m33);
        }
        public static bool operator !=(M4X4 lhs, M4X4 rhs)
        {
            return !(lhs == rhs);
        }
        public static implicit operator Matrix4x4(M4X4 q)
        {
            return new Matrix4x4(
                new Vector4(
                q.m00,
                q.m10,
                q.m20,
                q.m30),
                new Vector4(
                q.m01,
                q.m11,
                q.m21,
                q.m31),
                new Vector4(
                q.m02,
                q.m12,
                q.m22,
                q.m32),
                new Vector4(
                q.m03,
                q.m13,
                q.m23,
                q.m33)
                );
        }

        public static M4X4 Transpose(M4X4 original)
        {
            M4X4 MatrizParaRetornar = original;
            MatrizParaRetornar.m10 = original.m01;
            MatrizParaRetornar.m01 = original.m10;
            MatrizParaRetornar.m20 = original.m02;
            MatrizParaRetornar.m02 = original.m20;
            MatrizParaRetornar.m21 = original.m12;
            MatrizParaRetornar.m12 = original.m21;
            MatrizParaRetornar.m30 = original.m03;
            MatrizParaRetornar.m03 = original.m30;
            MatrizParaRetornar.m31 = original.m13;
            MatrizParaRetornar.m13 = original.m31;
            MatrizParaRetornar.m32 = original.m23;
            MatrizParaRetornar.m23 = original.m32;

            return MatrizParaRetornar;
        }

        public void Transpose()
        {
            m10 = m01;
            m01 = m10;
            m20 = m02;
            m02 = m20;
            m21 = m12;
            m12 = m21;
            m30 = m03;
            m03 = m30;
            m31 = m13;
            m13 = m31;
            m32 = m23;
            m23 = m32;

            /* 
              matriz original =            Matriz transpuesta =               
                m00, m01, m02, m03          m00, m10, m20, m30
                m10, m11, m12, m13          m01, m11, m21, m31
                m20, m21, m22, m23          m02, m12, m22, m32
                m30, m31, m32, m33          m03, m31, m23, m33             
           */
        }

        public Vector4 GetRow(int RowPos)
        {
            Vector4 RowToReturn =  Vector4.zero;
            switch (RowPos)
            {
                case 0:
                    RowToReturn = new Vector4(m00, m01, m02, m03);
                    break;
                case 1:
                    RowToReturn = new Vector4(m10, m11, m12, m13);
                    break;
                case 2:
                    RowToReturn = new Vector4(m20, m21, m22, m23);
                    break;
                case 3:
                    RowToReturn = new Vector4(m30, m31, m32, m33);
                    break;
                default:
                    
                    break;
            }

            return RowToReturn;
        }


        public void Inverse()
        {
            float chequeo = Matrix4x4.Determinant(this);   /// si el determinante de la matriz es 0 no se puede invertir

            if (chequeo == 0)
            {
            }
            else 
            {
                M4X4 resultado = M4X4.identity;
                this.m00 = this.m00 / this.m00;
                this.m01 = this.m01 / this.m00;
                this.m02 = this.m02 / this.m00;
                this.m03 = this.m03 / this.m00;
                resultado.m00 = resultado.m00 / this.m00;
                resultado.m01 = resultado.m01 / this.m00;
                resultado.m02 = resultado.m02 / this.m00;
                resultado.m03 = resultado.m03 / this.m00;

            }

            /* 
              matriz original =                         
                m00, m01, m02, m03        
                m10, m11, m12, m13        
                m20, m21, m22, m23        
                m30, m31, m32, m33             
           */
        }

        public void SetColumn(Vector4 Column, float ColumnPos)
        {
            switch (ColumnPos)
            {
                case 0:
                    m00 = Column.x;
                    m10 = Column.y;
                    m20 = Column.z;
                    m30 = Column.w;
                    break;
                case 1:
                    m01 = Column.x;
                    m11 = Column.y;
                    m21 = Column.z;
                    m31 = Column.w;
                    break;
                case 2:
                    m02 = Column.x;
                    m12 = Column.y;
                    m22 = Column.z;
                    m32 = Column.w;
                    break;
                case 3:
                    m03 = Column.x;
                    m13 = Column.y;
                    m23 = Column.z;
                    m33 = Column.w;
                    break;
                default:

                    break;
            }

        }
        public  Vector3 lossyScale()
        {
            Vector3 lossy = Vector3.zero;
            lossy.x = m00;
            lossy.y = m11;
            lossy.z = m22;
            return lossy;
        }

        public void SetRow(Vector4 Row, float RowPos)
        {
            switch (RowPos)
            {
                case 0:
                    m00 = Row.x;
                    m01 = Row.y;
                    m02 = Row.z;
                    m03 = Row.w;
                    break;
                case 1:
                    m10 = Row.x;
                    m11 = Row.y;
                    m12 = Row.z;
                    m13 = Row.w;
                    break;
                case 2:
                    m20 = Row.x;
                    m21 = Row.y;
                    m22 = Row.z;
                    m23 = Row.w;
                    break;
                case 3:
                    m30 = Row.x;
                    m31 = Row.y;
                    m32 = Row.z;
                    m33 = Row.w;
                    break;
                default:

                    break;
            }

        }     
    }
}
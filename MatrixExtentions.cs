using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public static class MatrixExtentions
    {   
        /// <summary>
        /// Возвращает наибольший элемент в матрице
        /// </summary>
        public static C Max<C>(this Matrix<C> matrix) where C : IComparable
        {
            if (matrix.IsEmpty()) return default(C);
            C max = matrix[0][0];
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    if (max.CompareTo(matrix[i][j]) < 0) max = matrix[i][j];
            return max;
        }

        /// <summary>
        /// Возвращает элемент с наиболее длинным строковым представлением
        /// </summary>
        public static T Longest<T>(this Matrix<T> matrix)
        {
            if (matrix.IsEmpty()) return default(T);
            T longest = matrix[0][0];
            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    if (longest.ToString().Length < matrix[i][j].ToString().Length) longest = matrix[i][j];
            return longest;
        }

        /// <summary>
        /// Возвращает строкове представление матрицы, в котором под каждый элемент выделено одинаковое количество места 
        /// </summary>
        public static string ToFormatedString<T>(this Matrix<T> matrix)
        {
            StringBuilder sb = new StringBuilder();
            int formatLenght = matrix.Longest().ToString().Length;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++) sb.Append(
                        string.Format($"{{0,{formatLenght + 1}}}",
                        matrix[i][j])
                    );
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<int> Mul(this Matrix<int> thisMatrix, Matrix<int> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<int> result = new Matrix<int>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<float> Mul(this Matrix<float> thisMatrix, Matrix<int> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<float> result = new Matrix<float>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<float> Mul(this Matrix<float> thisMatrix, Matrix<float> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<float> result = new Matrix<float>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<double> Mul(this Matrix<double> thisMatrix, Matrix<int> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<double> result = new Matrix<double>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<double> Mul(this Matrix<double> thisMatrix, Matrix<float> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<double> result = new Matrix<double>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }

        /// <summary>
        /// Производит умножение матриц, если произвести умножение не возможно, то вернется текущая матрица 
        /// </summary>
        public static Matrix<double> Mul(this Matrix<double> thisMatrix, Matrix<double> matrix)
        {
            if (thisMatrix.Rows != matrix.Columns) return thisMatrix;
            if (thisMatrix.Columns != matrix.Rows) return thisMatrix;
            Matrix<double> result = new Matrix<double>(thisMatrix.Rows, thisMatrix.Rows);
            for (int i = 0; i < thisMatrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    for (int k = 0; k < thisMatrix.Columns; k++)
                        result[i][j] += thisMatrix[i][k] * matrix[k][j];
            return result;
        }
    }
}

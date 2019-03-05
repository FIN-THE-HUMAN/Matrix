using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix<T>
    {
        private T[][] Elements { get; set; }

        /// <summary>
        /// Количество строк в матрице
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Количество столбцов в матрице
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр матрицы размером rows строк и columns столбцов
        /// </summary>
        public Matrix(int _rows, int _columns)
        {
            if (Rows >= 0 && Columns >= 0)
            {
                Elements = new T[_rows][];
                for (int i = 0; i < _rows; i++)
                {
                    Elements[i] = new T[_columns];
                    for (int j = 0; j < _columns; j++) Elements[i][j] = default(T);
                }
                Rows = _rows;
                Columns = _columns;
            }
            else
            {
                Rows = 0;
                Columns = 0;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр матрицы, ичпользуя в качестве источника данных входный двумерный массив
        /// </summary>
        public Matrix(T[,] matrix)
        {
            Elements = new T[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Elements[i] = new T[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++) Elements[i][j] = matrix[i, j];
            }
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
        }

        public T[] this[int index]
        {
            get
            {
                return Elements[index];
            }

            set
            {
                Elements[index] = value;
            }
        }

        public T this[int rowIndex, int columnIndex]
        {
            get
            {
                return Elements[rowIndex][columnIndex];
            }

            set
            {
                Elements[rowIndex][columnIndex] = value;
            }
        }

        /// <summary>
        /// Указывает является ли текущая матрица пустой
        /// </summary>
        public bool IsEmpty()
        {
            if (Rows == 0) return true;
            if (Columns == 0) return true;
            return false;
        }

        /// <summary>
        /// Очищаяет матрицу заполняя еще значениями по умолчанию - default(T)
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++) Elements[i][j] = default(T);
            }
        }

        /// <summary>
        /// Указывает встречается ли данный элемент в матрице
        /// </summary>
        public bool Contains(T item)
        {
            foreach (var list in Elements)
                foreach (var e in list)
                    if (e.Equals(item)) return true;
            return false;
        }

        /// <summary>
        /// Возвращяет матрицу со значениями, соответсвующими индексам первого вхождения данного элемента в матрице.
        /// Если элемент не найден, вернется -1 и -1.
        /// </summary>
        public Matrix<int> Find(T item)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (Elements[i][j].Equals(item))
                        return new Matrix<int>(1, 2) { [0, 0] = i, [0, 1] = j };
            return new Matrix<int>(1, 2) { [0, 0] = -1, [0, 1] = -1 };
        }

        /// <summary>
        /// Возвращяет список матриц со значениями, соответсвующими индексам вхождений данного элемента в матрице.
        /// Если элемент не найден, вернется -1 и -1.
        /// </summary>
        public List<Matrix<int>> FindAll(T item)
        {
            List<Matrix<int>> result = new List<Matrix<int>>();
            bool find = false;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (Elements[i][j].Equals(item))
                    {
                        find = true;
                        result.Add(new Matrix<int>(1, 2) { [0, 0] = i, [0, 1] = j });
                    }
            if (!find) result.Add(new Matrix<int>(1, 2) { [0, 0] = -1, [0, 1] = -1 });
            return result;
        }

        /// <summary>
        /// Возвращает строковое представление матрицы
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++) sb.Append(Elements[i][j] + " ");
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает строковое представление матрицы с определенным для каждого элемента форматом format
        /// </summary>
        public string ToString(string elementFormat)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++) sb.Append(string.Format(elementFormat, Elements[i][j]));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает строковое представление матрицы, представляя элементы матрицы согласно описанной функции
        /// </summary>
        public string ToString(Func<T, string> elementRepresentationFunc)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++) sb.Append(elementRepresentationFunc(Elements[i][j]));
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает список элементов матрицы 
        /// </summary>
        public List<T> ToList()
        {
            var list = new List<T>();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    list.Add(Elements[i][j]);
            return list;
        }

        /// <summary>
        /// Возвращает подматрицу размером rows строк и columns столбцов, начиная с левого верхнего элемента матрицы
        /// </summary>
        public Matrix<T> SubMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) return new Matrix<T>(0, 0);
            if (rows >= Rows) rows = Rows;
            if (columns >= Columns) columns = Columns;
            T[,] result = new T[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    result[i, j] = Elements[i][j];
            return new Matrix<T>(result);
        }

        /// <summary>
        /// Возвращает подматрицу, начиная со startRows и startColumns, заканчивая endRows и endColumns
        /// </summary>
        public Matrix<T> SubMatrix(int startRows, int startColumns, int endRows, int endColumns)
        {
            if (startRows < 0) startRows = 0;
            if (startColumns < 0) startColumns = 0;
            if (endRows >= Rows) endRows = Rows - 1;
            if (endColumns >= Columns) endColumns = Columns - 1;

            if (endRows < startRows || endColumns < startColumns) return new Matrix<T>(0, 0);
            if (endRows < 0 || endColumns < 0) return new Matrix<T>(0, 0);
            if (startRows >= Rows || startColumns >= Columns) return new Matrix<T>(0, 0);

            T[,] result = new T[endRows - startRows + 1, endColumns - startColumns + 1];

            for (int i = startRows; i <= endRows; i++)
                for (int j = startColumns; j <= endColumns; j++)
                    result[i - startRows, j - startColumns] = Elements[i][j];
            return new Matrix<T>(result);
        }

        /// <summary>
        /// Возвращает транспонированную матрицу
        /// </summary>
        public Matrix<T> Transpose()
        {
            if (Rows != Columns) return this;
            T[,] result = new T[Rows, Columns];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result[i, j] = Elements[j][i];
            return new Matrix<T>(result);
        }

        /// <summary>
        /// Применяет указанную функцию ко всем элементам матрицы
        /// </summary>
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    action(Elements[i][j]);
        }
    }
}

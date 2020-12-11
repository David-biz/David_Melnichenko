using System;
using System.Collections.Generic;
using System.Text;

namespace _20_Lab7_2 {
	class MyMatrix<T> {

		// Создать двомерный список
		readonly List<List<T>> matrix;

		public MyMatrix(int width, int height) {
			matrix = new List<List<T>>();  // Столпцы.
			for (int i = 0; i < width; i++) {
				matrix.Add(new List<T>());  // Рядки
				for (int j = 0; j < height; j++) {
					matrix[i].Add(default);  // Матрица значения поумолчанию 
				}
			}
		}

		public T this[int x, int y] {
			get => matrix[x][y];
			set => matrix[x][y] = value;
		}

		public int Width {
			get => matrix.Count;
		}
		public int Height {
			get => matrix[0].Count;
		}

		public void AddOneColumn() {
			matrix.Add(new List<T>());
			for (int i = 0; i < Height; i++) {
				matrix[^1].Add(default);
			}
		}
		public void RemoveOneColumn() {
			matrix.RemoveAt(matrix.Count - 1);
		}
		public void RemoveOneColumnAt(int position) {
			matrix.RemoveAt(position);
		}
		public void AddOneRow() {
			for (int i = 0; i < matrix.Count; i++) {
				matrix[i].Add(default);
			}
		}
		public void RemoveOneRow() {
			for (int i = 0; i < matrix.Count; i++) {
				matrix[i].RemoveAt(matrix[i].Count - 1);
			}
		}
	}
}

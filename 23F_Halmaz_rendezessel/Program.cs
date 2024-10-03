using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23F_Halmaz_rendezessel
{
	internal class Program
	{

		class HalmazRendezessel<T>
		{
			List<T> lista;
			Func<T, T, int> comparator;

			public HalmazRendezessel(Func<T, T, int> comparator)
			{
				this.lista = new List<T>();
				this.comparator = comparator;

			}

			public HalmazRendezessel(List<T> lista, Func<T, T, int> comparator)
			{
				this.lista = new List<T>(lista);
				Beszuró_rendezés(this.lista, comparator);
				this.comparator = comparator;
			}

			static void Csere<T>(List<T> lista, int i, int j)
			{
				T temp = lista[i];
				lista[i] = lista[j];
				lista[j] = temp;
			}

			public static void Beszuró_rendezés(List<T> lista, Func<T, T, int> comparator)
			{
				for (int i = 1; i < lista.Count; i++)
				{
					Süllyesztés(lista, i, comparator);
				}
			}

			public static void Süllyesztés(List<T> lista, int i, Func<T, T, int> comparator)
			{
				while (0 < i && comparator(lista[i - 1], lista[i]) == 1)
				{
					Csere(lista, i - 1, i);
					i--;
				}
			}


			private int Helye(T x)
			{
				int e = 0;
				int v = this.lista.Count - 1;
				int k;
				do
				{
					k = (e + v) / 2;
					if (this.comparator(lista[k], x) == -1)
					{
						e = k + 1;
					}
					else if (this.comparator(lista[k], x) == 1)
					{
						v = k - 1;
					}
				} while (e <= v && this.comparator(lista[k], x) != 0);

				return this.comparator(lista[k], x) == 0 ? k : e;
			}
			public int Keres(T x)
			{
				int h = Helye(x);
				return comparator(lista[h], x) == 0 ? h : -1;
			}

			public bool Tartalmazza(T e) => comparator(lista[Helye(e)], e) == 0;
			public void Add(T e)
			{
				int h = Helye(e);
				if (comparator(lista[h], e)!=0)
				{
					this.lista.Insert(h, e);
				}
			}

			public static HalmazRendezessel<T> operator -(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}

			public int Count => this.lista.Count;
			/// <summary>
			/// Összefuttatás
			/// </summary>
			/// <param name="a"></param>
			/// <param name="b"></param>
			/// <returns></returns>
			/// <exception cref="NotImplementedException"></exception>
			public static HalmazRendezessel<T> operator +(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				int i = 0;
				int j = 0;
				HalmazRendezessel<T> result = new HalmazRendezessel<T>(a.comparator);

				while (i < a.Count && j < b.Count)
				{
					if (result.comparator(a.lista[i], b.lista[j]) == -1)
					{
						result.Add(a.lista[i]);
						i++;
					}
					else if (result.comparator(a.lista[i], b.lista[j]) == 1)
					{
						result.Add(b.lista[j]);
						j++;
					}
					else
					{
						result.Add(a.lista[i]);
						i++;
						j++;
					}
				}

				while (i < a.Count)
				{
					result.Add(a.lista[i]);
					i++;
				}

				while (j < b.Count)
				{
					result.Add(b.lista[j]);
					j++;
				}

				return result;
			}

			public static HalmazRendezessel<T> operator *(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}

			public static bool operator <(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator <=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator >(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator >=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator ==(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}
			public static bool operator !=(HalmazRendezessel<T> a, HalmazRendezessel<T> b)
			{
				throw new NotImplementedException();
			}

			public override string ToString()
			{
				return "{ "+string.Join("; ", this.lista) +"}";
			}

		}

		static int szokasos(int a, int b)
		{
			if (a < b)
				return -1;
			if (a > b)
				return 1;
			return 0;
		}
		static void Main(string[] args)
		{
			HalmazRendezessel<int> h = new HalmazRendezessel<int>(new List<int> { 3, 7, 1, 2, 6, 1, 2 }, szokasos);
			HalmazRendezessel<int> g = new HalmazRendezessel<int>(new List<int> { 1, 2, 3, 5, 8, 9, 10, 14, 17, 18 }, szokasos);

            Console.WriteLine(h);

        }
	}
}

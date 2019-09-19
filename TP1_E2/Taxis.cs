using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_E2
{
	[Serializable]
	public class Taxis
	{
		private string refVeh2;
		private string zone;
		private string immatr;
		private string nbrPlace;
		private string marque;

		public Taxis(string refVeh2, string zone, string immatr, string nbrPlace, string marque)
		{
			RefVeh2 = refVeh2;
			Zone = zone;
			Immatr = immatr;
			NbrPlace = nbrPlace;
			Marque = marque;
		}

		public string RefVeh2 { get => refVeh2; set => refVeh2 = value; }

		public string Zone { get => zone; set => zone = value; }

		public string Immatr { get => immatr; set => immatr = value; }

		public string NbrPlace { get => nbrPlace; set => nbrPlace = value; }

		public string Marque { get => marque; set => marque = value; }

		public override string ToString()
		{
			return RefVeh2 + Zone + Immatr +  NbrPlace +  Marque;
		}
	}
}

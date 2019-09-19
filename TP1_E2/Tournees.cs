using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_E2
{
	[Serializable]
	public class Tournees
	{
		private string orgine;
		private string destination;
		private string heureDepart;
		private string client;
		private string refVeh3;

		public Tournees(string orgine, string destination, string heureDepart, string client, string refVeh3)
		{
			Orgine = orgine;
			Destination = destination;
			HeureDepart = heureDepart;
			Client = client;
			RefVeh3 = refVeh3;
		}

		public string Orgine { get => orgine; set => orgine = value; }

		public string Destination { get => destination; set => destination = value; }

		public string HeureDepart { get => heureDepart; set => heureDepart = value; }

		public string Client { get => client; set => client = value; }

		public string RefVeh3 { get => refVeh3; set => refVeh3 = value; }


		public override string ToString()
		{
			return Orgine + Destination + HeureDepart + Client + RefVeh3;
		}

	}
}

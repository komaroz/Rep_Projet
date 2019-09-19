using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_E2
{
    [Serializable]
    public class Chauffeurs
    {
        private string nom;
        private string tel;
        private string numPermi;
        private string refVeh;
        private string prenom;

        public Chauffeurs(string nom, string prenom, string tel, string numPermi, string refVeh)
        {
            Nom = nom;
            Prenom = prenom;
            Tel = tel;
            NumPermi = numPermi;
            RefVeh = refVeh;
        }

        public string Nom
        {
            get { return (nom); }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string NumPermi
        {
            get { return numPermi; }
            set { numPermi = value; }
        }

        public string RefVeh
        {
            get { return refVeh; }
            set { refVeh = value; }
        }


        public override string ToString()
        {
            return Nom + " " + Prenom + " " + Tel + " " + NumPermi + " " + RefVeh;
        }

    }
}

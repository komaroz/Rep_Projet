using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TP1_E2
{
    /// <summary>
    /// Logique d'interaction pour Consultation.xaml
    /// </summary>
    public partial class Consultation : Window
    {

        string path = @"E:\Programmeur-analyste\Session E19\420-EAT-LI PROGRAMMATION ORIENTÉE OBJET III\Travail pratique\TP1_E2\TP1_E2\bin\";
        string namefile = "TP1_E2.bin";

        List<Chauffeurs> chauffeurs;
        int indificateur;
        
        public int Indificateur { get => indificateur; set => indificateur = value; }

        public Consultation()
        {
            InitializeComponent();
            this.Reinitialiser();
        }


        public void Reinitialiser()
        {
            chauffeurs = new List<Chauffeurs>();
            //chauffeurs = Lecture(path + namefile);
            ListView1.ItemsSource = chauffeurs;
        }



        //Désérialisation

        //private static List<Chauffeurs> Lecture(string path)
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    FileStream flux = null;

        //    //On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
        //    //si le fichier n'existe pas, une exception sera levée.
        //    flux = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
        //    //Retourne une liste de personnage
        //    return (List<Chauffeurs>)formatter.Deserialize(flux);

        //}

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indificateur = ListView1.SelectedIndex;
            MessageBoxResult closeWindow = MessageBox.Show("Voulez-vous choisir le chauffeur?", "Confirmez", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (closeWindow == MessageBoxResult.Yes)
            {
                this.Hide();
            }
        }
    }
}

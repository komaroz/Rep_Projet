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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {

        string path = @"E:\Programmeur-analyste\Session E19\420-EAT-LI PROGRAMMATION ORIENTÉE OBJET III\Travail pratique\TP1_E2\TP1_E2\bin\";
        string namefile = "TP1_E2.bin";
        int indificateur;

        List<Chauffeurs> chauffeurs;
        List<Taxis> taxis;
        List<Tournees> tournees;
        Consultation consult;
        Chauffeurs chauffeur;
        Taxis taxi;
        Tournees tournee;
        bool reponse = false;


        public MainWindow()
        {
            InitializeComponent();
            this.Reinitialiser();
        }

        public void Reinitialiser()
        {
            chauffeurs = new List<Chauffeurs>();
            taxis = new List<Taxis>();
            tournees = new List<Tournees>();
            consult = new Consultation();
            reponse = false;
        }

        private void btn_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                Verifier();
            } while (reponse == true);

            chauffeurs.Add(chauffeur);
            taxis.Add(taxi);
            tournees.Add(tournee);
            Vider();



        }

        private void btn_Fermer_Click(object sender, RoutedEventArgs e)
        {
            Enregistrer(chauffeurs, path + namefile);
            Enregistrer(taxis, path + namefile);
            Enregistrer(tournees, path + namefile);
            Fermeture();
        }


        private void btn_Modifier_Click(object sender, RoutedEventArgs e)
        {
            Modify();
        }

        private void btn_ModifierTo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ModifierT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Consulter_Click(object sender, RoutedEventArgs e)
        {
            Rechercher(nom.Text);

            MessageBox.Show("L'index du chauffeurs est:" + indificateur);
            //consult.ShowDialog();

            //indificateur = consult.Indificateur;

            //nom.Text = chauffeurs[indificateur].Nom;
            //prenom.Text = chauffeurs[indificateur].Prenom;
            //tel.Text = chauffeurs[indificateur].Tel;
            //numPermi.Text = chauffeurs[indificateur].NumPermi;
            //refVeh.Text = chauffeurs[indificateur].RefVeh;

        }

        private void btn_ConsulterT_Click(object sender, RoutedEventArgs e)
        {



        }

        private void btn_ConsulterTo_Click(object sender, ContextMenuEventArgs e)
        {

        }
        private void btn_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Removing(nom.Text);
            MessageBox.Show("Le chauffeur est supprimé");
        }

        private void btn_SupprimerT_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_SupprimerTo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tcSample.SelectedIndex - 1;
            if (newIndex < 0)
                newIndex = tcSample.Items.Count - 1;
            tcSample.SelectedIndex = newIndex;
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tcSample.SelectedIndex + 1;
            if (newIndex >= tcSample.Items.Count)
                newIndex = 0;
            tcSample.SelectedIndex = newIndex;
        }

        private void Fermeture()
        {
            MessageBoxResult key = MessageBox.Show("Voulez-vous vraiment quitter sans suavgarder l'information ?", "Confirmez", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (key == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                MessageBoxResult key1 = MessageBox.Show("Voulez-vous voulez sauvgarder l'information avans qiitter?", "Confirmez", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (key1 == MessageBoxResult.Yes)
                {
                    Enregistrer(chauffeurs, path + namefile);
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show("Voulez-vous vraiment quitter ?", "Confirmez", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            e.Cancel = (key == MessageBoxResult.No);
        }

        public void Vider()
        {
            nom.Clear();
            prenom.Clear();
            tel.Clear();
            numPermi.Clear();
            refVeh.Clear();
            refVeh2.Clear();
            zone.Clear();
            immatricule.Clear();
            nbrPlace.Clear();
            marque.Clear();
            origine.Clear();
            dest.Clear();
            hrDepart.Clear();
            client.Clear();
            refVeh3.Clear();
        }

        public void Verifier()
        {

            if (tcSample.SelectedIndex == 0)
            {
                chauffeur = new Chauffeurs(nom.Text, prenom.Text, tel.Text, numPermi.Text, refVeh.Text);

                if (nom.Text.Length < 3)
                {
                    MessageBox.Show("Le nom doit avoirdoit avoir au moins 3 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    nom.Focus();

                }
                else if (prenom.Text.Length < 3)
                {
                    MessageBox.Show("Le prénom doit avoir au moins 3 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    prenom.Focus();


                }
                else if (tel.Text.Length != 10)
                {
                    MessageBox.Show("Le numéro de téléphone doit avoir  10 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    tel.Focus();

                }
                else if (numPermi.Text.Length < 3)
                {
                    MessageBox.Show("Le numéro de permis doit avoir au moins 10 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    numPermi.Focus();

                }
                else if (refVeh.Text.Length < 4)
                {
                    MessageBox.Show("Le référence pour le véhicule doit avoir moins 4 caractères!");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    refVeh.Focus();

                }
                else
                {
                    MessageBox.Show("Vous avez entré " + nom.Text + " " + prenom.Text + " " + tel.Text + " " + numPermi.Text + " " + refVeh.Text);
                    MessageBox.Show("Le chauffeur est ajouté");
                    reponse = false;
                }

            }
            else if (tcSample.SelectedIndex == 1)
            {
                taxi = new Taxis(refVeh2.Text, zone.Text, immatricule.Text, nbrPlace.Text, marque.Text);

                if (refVeh2.Text.Length < 4)
                {
                    MessageBox.Show("Le référence pour le véhicule doit avoir moins 4 caractères!");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    refVeh2.Focus();
                }
                if (zone.Text.Length < 3)
                {
                    MessageBox.Show("Le zone doit avoirdoit avoir au moins 3 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    zone.Focus();

                }
                else if (immatricule.Text.Length < 10)
                {
                    MessageBox.Show("Le prénom doit avoir au moins 10 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    immatricule.Focus();


                }
                else if (nbrPlace.Text.Length < 4)
                {
                    MessageBox.Show("Le numéro de places doit avoir  au moins 4 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    nbrPlace.Focus();

                }
                else if (marque.Text.Length < 5)
                {
                    MessageBox.Show("Le numéro de permis doit avoir au moins 5 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    marque.Focus();

                }
                else
                {
                    MessageBox.Show("Vous avez entré " + refVeh2.Text + " " + zone.Text + " " + immatricule.Text + " " + nbrPlace.Text + " " + marque.Text);
                    MessageBox.Show("Le taxi est ajouté");
                    reponse = false;
                }

            }
            else if (tcSample.SelectedIndex == 2)
            {
                tournee = new Tournees(origine.Text, dest.Text, hrDepart.Text, client.Text, refVeh3.Text);

                if (origine.Text.Length < 4)
                {
                    MessageBox.Show("L'origine doit avoir moins 4 caractères!");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    origine.Focus();
                }
                else if (dest.Text.Length < 3)
                {
                    MessageBox.Show("Le destination doit avoir au moins 3 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    dest.Focus();


                }
                else if (hrDepart.Text.Length != 4)
                {
                    MessageBox.Show("L'heure de départ doit avoir  4 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    hrDepart.Focus();

                }
                else if (client.Text.Length < 10)
                {
                    MessageBox.Show("Le client doit avoir au moins 10 caractères");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    client.Focus();

                }
                else if (refVeh3.Text.Length < 4)
                {
                    MessageBox.Show("Le référence pour le véhicule doit avoir moins 4 caractères!");
                    MessageBox.Show("Les champs sont remplis incorrectement!");
                    refVeh3.Focus();
                }
                else
                {
                    MessageBox.Show("Vous avez entré " + origine.Text + " " + dest.Text + " " + hrDepart.Text + " " + client.Text + " " + refVeh3.Text);
                    MessageBox.Show("Le tournee est ajouté");
                    reponse = false;
                }

            }
            else
                reponse = true;

        }
        private bool FonctionDeRecherche(Chauffeurs c)
        {
            if (c.Nom == nom.Text)
                return true;
            return false;

        }
        public void Rechercher(string nom)  //Méthode appellée pour rechercher une personne.
        {
            try
            {
                chauffeurs = Lecture(path + namefile);
                Chauffeurs ch = chauffeurs.Find(FonctionDeRecherche);

                prenom.Text = ch.Prenom;
                tel.Text = ch.Tel;
                numPermi.Text = ch.NumPermi;
                refVeh.Text = ch.RefVeh;
                indificateur = chauffeurs.IndexOf(ch);


            }
            catch (Exception e)
            {

                MessageBox.Show("Le chauffeur que vous cherchez n'est pas trouvé", e.Message);

            }
        }

        public void Removing(string nom)  //Méthode appellée pour rechercher une personne.
        {

            MessageBox.Show(""+indificateur);
            chauffeurs.Remove(chauffeurs[indificateur]);
            Vider();
        }


        public void Modify()  //Méthode appellée pour rechercher une personne.
        {

            if (tcSample.SelectedIndex == 0)
            {
                chauffeurs[indificateur].Nom = nom.Text;
                chauffeurs[indificateur].Prenom = prenom.Text;
                chauffeurs[indificateur].Tel = tel.Text;
                chauffeurs[indificateur].NumPermi = numPermi.Text;
                chauffeurs[indificateur].RefVeh = refVeh.Text;
                MessageBox.Show("Les informations ont été  modifié");
            }
            else if (tcSample.SelectedIndex == 1)
            {
                taxi = new Taxis(refVeh2.Text, zone.Text, immatricule.Text, nbrPlace.Text, marque.Text);
                taxis[indificateur].RefVeh2 = refVeh2.Text;
                taxis[indificateur].Zone = zone.Text;
                taxis[indificateur].Immatr = immatricule.Text;
                taxis[indificateur].NbrPlace = nbrPlace.Text;
                taxis[indificateur].Marque = marque.Text;

                MessageBox.Show("Les informations ont été  modifié");
            }
            else if (tcSample.SelectedIndex == 2)
            {
                tournee = new Tournees(origine.Text, dest.Text, hrDepart.Text, client.Text, refVeh3.Text);

                tournees[indificateur].Orgine = origine.Text;
                tournees[indificateur].Destination = dest.Text;
                tournees[indificateur].HeureDepart = hrDepart.Text;
                tournees[indificateur].Client = client.Text;
                tournees[indificateur].RefVeh3 = refVeh3.Text;
                MessageBox.Show("Les informations ont été  modifié");
            }
            else
                MessageBox.Show("Cou-cou");



        }

        private void Enregistrer(object liste, string path)
        {

            //On utilise la classe BinaryFormatter dans le namespace System.Runtime.Serialization.Formatters.Binary.
            BinaryFormatter formatter = new BinaryFormatter();
            //La classe BinaryFormatter ne fonctionne qu'avec un flux.
            //Nous allons donc utiliser un FileStream.
            FileStream flux = null;
            try
            {
                //On ouvre le flux en mode création / écrasement de fichier et on
                //donne au flux le droit en écriture seulement.
                flux = new FileStream(path, FileMode.Append, FileAccess.ReadWrite);
                // On sérialise !
                formatter.Serialize(flux, liste);
                //On s'assure que le tout soit écrit dans le fichier.
                flux.Flush();
            }
            catch { }
            finally
            {
                //Et on ferme le flux.
                if (flux != null)
                    flux.Close();
            }

        }

        //Désérialisation

        private List<Chauffeurs> Lecture(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;

            //On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
            //si le fichier n'existe pas, une exception sera levée.
            flux = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            //Retourne une liste de personnage
            return (List<Chauffeurs>)formatter.Deserialize(flux);

        }

        private List<Taxis> LectureT(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;

            //On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
            //si le fichier n'existe pas, une exception sera levée.
            flux = new FileStream(path + namefile, FileMode.Open, FileAccess.ReadWrite);
            //Retourne une liste de personnage
            return (List<Taxis>)formatter.Deserialize(flux);

        }

        private List<Tournees> LectureTO(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream flux = null;

            //On ouvre le fichier en mode lecture seule. De plus, puisqu'on a sélectionné le mode Open,
            //si le fichier n'existe pas, une exception sera levée.
            flux = new FileStream(path + namefile, FileMode.Open, FileAccess.ReadWrite);
            ;
            //Retourne une liste de personnage
            return (List<Tournees>)formatter.Deserialize(flux);

        }
    }

    /*https://habr.com/ru/post/270413/ 
	https://www.wpf-tutorial.com/ru/68/%D1%8D%D0%BB%D0%B5%D0%BC%D0%B5%D0%BD%D1%82-%D1%83%D0%BF%D1%80%D0%B0%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F-tabcontrol/%D0%B8%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-wpf-tabcontrol/ */
}





using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

using librairie_projet2;

public partial class Projet2 : System.Web.UI.Page
{
   public libProjet2 librairie = new libProjet2();

   Panel panEntete = null, panCorps = null, panPiedPage = null;
   Label lblEntete1 = null, lblEntete2 = null;
   Button btnRecommencerAvecConfirmation = null, btnRecommencer = null;
   HiddenField hiddenField = null;
   Table table = null;
   TableRow tr1 = null, tr2 = null;
   TableCell tdPremiereCellule = null, tdDeuxiemeCellule = null, tdTroisiemeCellule = null;
   Label lblMotRechercheGauche = null, lblMotRechercheCentre = null, lblMotRechercheDroite = null;
   Label lblLettresAChoisir = null;
   Label lblPiedDePage = null;

   void Page_Load()
   {
      /*if (IsPostBack)
      {
         //table.Controls.Clear();
         //tr1.Controls.Clear();
         //tr2.Controls.Clear();
         //tdPremiereCellule.Controls.Clear();
         //tdDeuxiemeCellule.Controls.Clear();
         //tdTroisiemeCellule.Controls.Clear();

         //panEntete.Controls.Clear();
         //panCorps.Controls.Clear();
         //panPiedPage.Controls.Clear();

         panEntete = null;
         panCorps = null;
         panPiedPage = null;

         lblEntete1 = null;
         lblEntete2 = null;

         btnRecommencerAvecConfirmation = null;
         btnRecommencer = null;

         hiddenField = null;

         table = null;
         tr1 = null;
         tr2 = null;
         tdPremiereCellule = null;
         tdDeuxiemeCellule = null;
         tdTroisiemeCellule = null;

         lblMotRechercheGauche = null;
         lblMotRechercheCentre = null;
         lblMotRechercheDroite = null;

         lblLettresAChoisir = null;

         lblPiedDePage = null;
      }*/

      creationFormulaire();
   }

   void rechargePageOnClick(object sender, EventArgs e)
   {
      Response.Redirect(Request.RawUrl);
   }

   void creationFormulaire()
   {
      Int32 intErreur = 0;

      /* Création des quatre panneaux */
      panEntete = panEntete ?? librairie.divDYN(phDynamique, "panEntete");
      panCorps = panCorps ?? librairie.divDYN(phDynamique, "panCorps");
      panPiedPage = panPiedPage ?? librairie.divDYN(phDynamique, "panPiedPage", "sDivPiedPage");

      /*
       * Création des controles pour panEntete
       */
      lblEntete1 = lblEntete1 ?? librairie.lblDYN(phDynamique, "ctlEntete1", "Jeu du Bonhomme pendu", "sTitreApplication"); 
      lblEntete2 = lblEntete2 ?? librairie.lblDYN(phDynamique, "ctlEntete2", "par Mohamed H. Guelleh ", "sTitreApplication");

      btnRecommencerAvecConfirmation = btnRecommencerAvecConfirmation ?? librairie.btnDYN(phDynamique, "btnRecommencerAvecConfirmation", "Recommencer", "sReduit", rechargePageOnClick, new String[5] { "", "", "if (!confirmationPourAnnuler()) { return(false) };", "", "" });
      btnRecommencer = btnRecommencer ?? librairie.btnDYN(phDynamique, "btnRecommencer", "Recommencer", "sInvisible sReduit", rechargePageOnClick);

      btnRecommencer.Style.Value = "display:none; visibility:hidden;";

      /*
       * Création des controles pour panCorps
       */
      hiddenField = hiddenField ?? librairie.hf(phDynamique, "hidMotCache", "");
      table = table ?? librairie.tableDYN(phDynamique, "table", "");
      tr1 = tr1 ?? librairie.trDYN(table);
      tr2 = tr2 ?? librairie.trDYN(table);
      tdPremiereCellule = tdPremiereCellule ?? librairie.tdDYN(tr1, "premiereCellule", "sPremiereCellule");
      tdDeuxiemeCellule = tdDeuxiemeCellule ?? librairie.tdDYN(tr1, "deuxiemeCellule", "sDeuxiemeCellule");
      tdTroisiemeCellule = tdTroisiemeCellule ?? librairie.tdDYN(tr2, "tdLettresRestantes", "sTroisiemeCellule");

      lblMotRechercheGauche = lblMotRechercheGauche ?? librairie.lblDYN(tdPremiereCellule, "lblMotRechercheGauche", "On recherche un mot de ", "sTitreSection");
      lblMotRechercheCentre = lblMotRechercheCentre ?? librairie.lblDYN(tdPremiereCellule, "lblMotRechercheCentre", "", "sTitreSection");
      lblMotRechercheDroite = lblMotRechercheDroite ?? librairie.lblDYN(tdPremiereCellule, "lblMotRechercheDroite", " lettres :", "sTitreSection");

      lblLettresAChoisir = lblLettresAChoisir ?? librairie.lblDYN(tdTroisiemeCellule, "lblLettresAChoisir", "Lettres à choisir", "sTitreSection");

      /*
       * Création des controles pour panPiedPage
       */
      lblPiedDePage = lblPiedDePage ?? librairie.lblDYN(phDynamique, "ctlPiedDePage", "&copy; Département d'informatique G.-G.", "sReduit");

      /*
       * Initialisation et ajout des controles dans les panneaux
       */
      tdPremiereCellule.Controls.Add(librairie.brDYN(phDynamique));
      tdPremiereCellule.Controls.Add(librairie.brDYN(phDynamique));

      // initialise mot
      String strHid = ((Request.QueryString["Mot"] == null) || ((Request.QueryString["Mot"] == "") || Request.QueryString["Mot"].Length > 28) || !(Regex.IsMatch(Request.QueryString["Mot"], @"([A-Za-z-']{1,28})"))) ? "anticonstitutionnellement" : Request.QueryString["Mot"].ToLower();

      lblMotRechercheCentre.Text = strHid.Length.ToString();

      ((HiddenField)Page.FindControl("hidMotCache")).Value = strHid;
      for (int i = 0; i < strHid.Length; i++)
      {
         librairie.img(tdPremiereCellule, "img" + i.ToString(), "vide", "sImage");
      }

      tdDeuxiemeCellule.RowSpan = 2;
      Image imgPendu = librairie.img(tdDeuxiemeCellule, "imgPendu", "pendu" + intErreur.ToString("00"), "sPendu");

      // initialise la valeur a vide
      //librairie.hf((Panel)Page.FindControl("panCorps"), "hidMotCache", "");


      tdTroisiemeCellule.Controls.Add(librairie.brDYN(phDynamique));
      tdTroisiemeCellule.Controls.Add(librairie.brDYN(phDynamique));

      //char[] az = Enumerable.Range('A', 26).Select(i => (Char)i).ToArray();
      /*List<Char> az = Enumerable.Range('A', 26).Select(i => (Char)i).ToList();
      az.Add('-');
      az.Add('\'');
      foreach (char c in az)
      {
         librairie.imgBtn(tdTroisiemeCellule, "img" + c.ToString(), c.ToString(), "sImage");
      }*/

      for (char c = 'A'; c <= 'Z'; c++)
      {
         librairie.imgBtn(tdTroisiemeCellule, "img" + c.ToString(), c.ToString().ToLower(), "sImage", new String[5] { "", "", "valideLettreSelectionnee(this); return false", "", "" });
      }
      librairie.imgBtn(tdTroisiemeCellule, "img-", "-", "sImage", new String[5] { "", "", "valideLettreSelectionnee(this); return false", "", "" });
      librairie.imgBtn(tdTroisiemeCellule, "img'", "'", "sImage", new String[5] { "", "", "valideLettreSelectionnee(this); return false", "", "" });

      panEntete.Controls.Add(lblEntete1);
      panEntete.Controls.Add(librairie.brDYN(phDynamique));
      panEntete.Controls.Add(lblEntete2);
      panEntete.Controls.Add(btnRecommencerAvecConfirmation);
      panEntete.Controls.Add(btnRecommencer);

      panCorps.Controls.Add(hiddenField);
      panCorps.Controls.Add(table);

      panPiedPage.Controls.Add(lblPiedDePage);
   }
}
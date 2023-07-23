using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace librairie_projet2
{
   public class libProjet2 : System.Web.UI.Page
   {
      public WebControl b(Control Conteneur, String strID)
      {
         return (WebControl)Conteneur.FindControl(strID);
      }

      /*
       * Pour les composants
       */
      public Literal brDYN(Control Conteneur)
      {
         Literal br = new Literal();
         br.Text = "<br />";
         Conteneur.Controls.Add(br);

         return br;
      }
      public Literal brDYN(Control Conteneur, Int16 intNb)
      {
         Literal br = new Literal();
         br.Text = "";
         for (Int16 i = 1; i <= intNb; i++)
         {
            br.Text += "<br />";
         }
         Conteneur.Controls.Add(br);

         return br;
      }

      public enum evenement { onmouseover, onmouseout, onclick, onchange, onrightclick };
      public Button btnDYN(Control Conteneur, String strID, String strValeur)
      {
         Button btn = new Button();
         btn.ID = strID;
         btn.Text = strValeur;
         Conteneur.Controls.Add(btn);
         return btn;
      }
      //
      public Button btnDYN(Control Conteneur, String strID, String strValeur, String strStyle)
      {
         Button btn = btnDYN(Conteneur, strID, strValeur);
         // V1 : "btn.Click += new EventHandler(nomFonctionClick)" pour ajouter ou "btn.Click -= new EventHandler(nomFonctionClick)" pour enlever
         btn.CssClass = strStyle;
         return btn;
      }
      //
      public Button btnDYN(Control Conteneur, String strID, String strValeur, String strStyle, EventHandler nomFonction)
      {
         Button btn = btnDYN(Conteneur, strID, strValeur, strStyle);
         // V1 : "btn.Click += new EventHandler(nomFonctionClick)" pour ajouter ou "btn.Click -= new EventHandler(nomFonctionClick)" pour enlever
         btn.Click += nomFonction;
         return btn;
      }

      public Button btnDYN(Control Conteneur, String strID, String strValeur, String strStyle, EventHandler nomFonction, String[] strArgs)
      {
         Button btn = btnDYN(Conteneur, strID, strValeur, strStyle, nomFonction);
         btn.Attributes.Add("onmouseover", strArgs[(int)evenement.onmouseover]);
         btn.Attributes.Add("onmouseout", strArgs[(int)evenement.onmouseout]);
         btn.Attributes.Add("onclick", strArgs[(int)evenement.onclick]);
         btn.Attributes.Add("onchange", strArgs[(int)evenement.onchange]);
         btn.Attributes.Add("oncontextmenu", strArgs[(int)evenement.onrightclick]);
         return btn;
      }

      /*public Button btnDYN(Control Conteneur, String strID, String strValeur, String strStyle, EventHandler nomFonction)
      {
         Button btn = btnDYN(Conteneur, strID, strValeur, nomFonction);
         btn.CssClass = strStyle;
         return btn;
      }*/

      /*
       * Commented now
       */
      /*public Button btnJsDYN(Control Conteneur, String strID, String strValeur, String strStyle, String strArgs)
      {
         Button btn = btnDYN(Conteneur, strID, strValeur, strStyle);
         btn.Attributes.Add("onclick", "return false;");
         btn.Attributes.Add("onclick", strArgs + "; return false");
         return btn;
      }*/

      public HiddenField hf(Control Conteneur, String strID, String strValeur)
      {
         HiddenField hiddenField = new HiddenField();
         hiddenField.ID = strID;
         hiddenField.Value = strValeur;
         Conteneur.Controls.Add(hiddenField);
         return hiddenField;
      }

      public Panel divDYN(Control Conteneur, String strID)
      {
         Panel panel = new Panel();
         panel.ID = strID;
         Conteneur.Controls.Add(panel);
         return panel;
      }
      public Panel divDYN(Control Conteneur, String strID, String strStyle)
      {
         Panel panel = divDYN(Conteneur, strID);
         panel.CssClass = strStyle;
         return panel;

      }

      public Label lblDYN(Control Conteneur, String strID, String strValeur)
      {
         Label label = new Label();

         label.ID = strID;
         label.Text = strValeur;

         Conteneur.Controls.Add(label);
         return label;
      }
      public Label lblDYN(Control Conteneur, String strID, String strValeur, String strStyle)
      {
         Label label = lblDYN(Conteneur, strID, strValeur);

         label.CssClass = strStyle;

         return label;
      }

      /*
       * Pour les validations
       */
      public RangeValidator rangeValidatorDYN(Control Conteneur, String strID, String strControlToValidate, String strMinimum, String strMaximum, String strType)
      {
         RangeValidator rangeValidator = new RangeValidator();

         rangeValidator.ID = strID;
         rangeValidator.ControlToValidate = strControlToValidate;
         rangeValidator.MinimumValue = strMinimum;
         rangeValidator.MaximumValue = strMaximum;

         switch (strType)
         {
            case "Currency": rangeValidator.Type = ValidationDataType.Currency; break;
            case "Date": rangeValidator.Type = ValidationDataType.Date; break;
            case "Double": rangeValidator.Type = ValidationDataType.Double; break;
            case "Integer": rangeValidator.Type = ValidationDataType.Integer; break;
            case "String": rangeValidator.Type = ValidationDataType.String; break;
            default: rangeValidator.Type = ValidationDataType.String; break;
         }

         Conteneur.Controls.Add(rangeValidator);
         return rangeValidator;
      }

      public RequiredFieldValidator requiredFieldValidatorDYN(Control Conteneur, String strID, String strControlToValidate)
      {
         RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();

         requiredFieldValidator.ID = strID;
         requiredFieldValidator.ControlToValidate = strControlToValidate;

         Conteneur.Controls.Add(requiredFieldValidator);
         return requiredFieldValidator;
      }

      /*
       * Pour le tableau
       */
      public Table tableDYN(Control Conteneur, String strID, String strStyle)
      {
         Table table = new Table();

         table.ID = strID;
         table.CssClass = strStyle;

         Conteneur.Controls.Add(table);
         return table;
      }

      public TextBox tbDYN(Control Conteneur, String strID, String strValeur, String strMaxLength, String strStyle)
      {
         TextBox textBox = new TextBox();

         textBox.ID = strID;
         textBox.Text = strValeur;
         textBox.MaxLength = Int16.Parse(strMaxLength);
         textBox.CssClass = strStyle;

         Conteneur.Controls.Add(textBox);
         return textBox;
      }

      public TableCell tdDYN(TableRow Conteneur, String strID, String strStyle)
      {
         TableCell tableCell = new TableCell();

         tableCell.ID = strID;
         tableCell.CssClass = strStyle;

         Conteneur.Controls.Add(tableCell);
         return tableCell;
      }

      public TableRow trDYN(Table Conteneur)
      {
         TableRow tableRow = new TableRow();

         Conteneur.Controls.Add(tableRow);
         return tableRow;
      }

      public Image img(Control Conteneur, String strID, String strValeur, String strStyle)
      {
         Image image = new Image();
         image.ID = strID;
         image.ImageUrl = "./images/" + strValeur + ".png";
         image.CssClass = strStyle;
         Conteneur.Controls.Add(image);
         return image;
      }
      public ImageButton imgBtn(Control Conteneur, String strID, String strValeur, String strStyle, String[] strArgs)
      {
         ImageButton image = new ImageButton();
         image.ID = strID;
         image.ImageUrl = "./images/" + strValeur + ".png";
         image.CssClass = strStyle;

         //image.OnClientClick = "return false;";
         image.Attributes.Add("onmouseover", strArgs[(int)evenement.onmouseover]);
         image.Attributes.Add("onmouseout", strArgs[(int)evenement.onmouseout]);
         image.Attributes.Add("onclick", strArgs[(int)evenement.onclick]);
         image.Attributes.Add("onchange", strArgs[(int)evenement.onchange]);
         image.Attributes.Add("oncontextmenu", strArgs[(int)evenement.onrightclick]);

         Conteneur.Controls.Add(image);
         return image;
      }
   }
}
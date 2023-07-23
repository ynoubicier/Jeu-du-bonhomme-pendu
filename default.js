// JS code

function confirmationPourAnnuler() {
   return confirm("D\351sirez-vous vraiement annuler la partie en cours ?" +
      "\n\nOK=OUI" +
      "\n\nAnnuler=NON");
}

function valideLettreSelectionnee(objThis) {
   // si l'image pendu n'est pas pendu ou trouve
   if ((document.getElementById('imgPendu').getAttribute('src') !== './images/pendu09.png') && (document.getElementById('imgPendu').getAttribute('src') !== './images/pendu10.png')) {
      objThis.style.display = 'none';
      objThis.style.visibility = 'hidden';

      var blnCharTrouve = false;
      var chObjThis = objThis.id.charAt(3)
      var strHid = b('hidMotCache')

      for (var i = 0; i < strHid.length; i++) {
         if (strHid.charAt(i).toString() === chObjThis.toString().toLowerCase()) {
            blnCharTrouve = true;
            document.getElementById('img' + i.toString()).setAttribute('src', './images/' + chObjThis.toLowerCase() + '.png');
         }
      }

      // pour check les erreurs
      var strImg = document.getElementById('imgPendu').getAttribute("src");
      var intImg = parseInt(strImg.substring(strImg.search("pendu") + 5, strImg.search("pendu") + 7));

      if (!blnCharTrouve) {
         intImg++;

         if (intImg < 10) {
            document.getElementById('imgPendu').setAttribute('src', './images/pendu0' + intImg.toString() + '.png');
         }
         else {
            document.getElementById('imgPendu').setAttribute('src', './images/pendu10.png');

         }
      }

      if (intImg === 9) { // nb erreur max atteint, game over
         b('lblMotRechercheGauche', "Le mot recherch\351 \351tait...");
         b('lblMotRechercheCentre', "");
         b('lblMotRechercheDroite', "");

         document.getElementById('tdLettresRestantes').style.visibility = "hidden";

         for (var i = 0; i < strHid.length; i++) {
            document.getElementById('img' + i.toString()).setAttribute('src', './images/' + strHid.charAt(i) + '.png');
         }

         document.getElementById('btnRecommencerAvecConfirmation').style.display = "none";
         document.getElementById('btnRecommencerAvecConfirmation').style.visibility = "hidden";

         document.getElementById('btnRecommencer').style.visibility = "visible";
         document.getElementById('btnRecommencer').style.display = "inline";
      }
      else {
         var strHid = b('hidMotCache')
         var blnTrouve = true;
         for (var i = 0; i < strHid.length; i++) {
            if (document.getElementById('img' + i.toString()).getAttribute('src') === './images/vide.png') {
               blnTrouve = false;
               break;
            }
         }

         // si aucune image n'est vide
         if (blnTrouve) {
            b('lblMotRechercheGauche', "Bravo! Vous avez trouv\351 le mot de " + strHid.length + " lettres :");
            b('lblMotRechercheCentre', "");
            b('lblMotRechercheDroite', "");

            document.getElementById('tdLettresRestantes').style.visibility = "hidden";

            document.getElementById('imgPendu').src = './images/pendu10.png';

            document.getElementById('btnRecommencerAvecConfirmation').style.display = "none";
            document.getElementById('btnRecommencerAvecConfirmation').style.visibility = "hidden";

            document.getElementById('btnRecommencer').style.visibility = "visible";
            document.getElementById('btnRecommencer').style.display = "inline";
         }
      }
   }
}
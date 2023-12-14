// See https://aka.ms/new-console-template for more information


string mot;
string cacher = "";
string lettre;
int vie = 10;
int essais = 0;
int nbTrouve = 0;
bool devine = false;

char lettreUpper;
char motUpper;
char cacherUpper;


Console.WriteLine("Pendu! Entrez un mot.");
mot = Console.ReadLine();

for (int i = 0; i < mot.Length; i++)
{
    cacher += "_";
}

for (int i = 0; i < 50; i++)
{
    Console.WriteLine(" ");
}


char[] cacherArray = cacher.ToCharArray();
char[] motArray = mot.ToCharArray();

do
{

    devine = false;
    Console.WriteLine(cacher);
    Console.WriteLine("Vous avez " + vie + " vies.");
    Console.WriteLine("Entrez une lettre ou un mot.");
    lettre = Console.ReadLine();
    essais++;

    if(lettre.ToUpper() == mot.ToUpper())
    {
        devine = true;
        cacher = mot;
    }
    else
    {
        if (lettre.Length == 1)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                lettreUpper = char.ToUpper(lettre[0]);
                motUpper = char.ToUpper(mot[i]); // Convertir le caractère dans mot en majuscule
                cacherUpper = char.ToUpper(cacher[i]); // Convertir le caractère dans cacher en majuscule

                if (lettreUpper == motUpper && lettreUpper != cacherUpper)
                {
                    devine = true;
                    cacherArray[i] = motArray[i];
                    nbTrouve++;
                }
            }
            cacher = new string(cacherArray);
        }
    }
    if(devine == false)
    {
        vie--;
    }
    Console.WriteLine(" ");
} while (cacher != mot && vie > 0);

if(cacher == mot)
{
    Console.WriteLine("Vous avez gagné en " + essais + " essais et il vous restait " + vie + " vies");
}
else
{
    Console.WriteLine("Vous avez perdu le mot était : " + mot);
    Console.WriteLine("Vous avez déjà trouvé " + nbTrouve + " lettres!");
}
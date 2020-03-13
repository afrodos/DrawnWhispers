using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

class gameUtils
{
    public gameUtils(string descriptionjsonFileName = "descriptions.json")
    {
        jsonFilename = descriptionjsonFileName;
    }

    private bool loaded = false;
    private JavaScriptSerializer js = new JavaScriptSerializer();
    private dynamic jsonObject;
    private string jsonFilename;
    Random r = new Random();

    public string[,] getOrder(string[] people)
    {
        string[,] orderedArr = new string[people.Length, people.Length];
        for (int i = 0; i < people.Length; i++)
        {
            for (int x = 0; x < people.Length; x++)
            {
                orderedArr[i, x] = people[overflow(x+i, people.Length)];
            }
        }
        return orderedArr; 
    }//YEEEEEEEEEEEEEEEEEEEEEEES HIJ DOET HET
    
    /*
    public string getRandomDescription(string theme = "standard")
    {
        string[] desarr = getDescriptionArr(jsonFilename);
        return "lol"; desarr[r.Next(desarr.Length)];
    }
    */

    public string getRandomDescription(string theme = "standard")//deze hele function is het domste wat ik ooit heb gemaakt maar het werkt
    {
        if (loaded)
        {
            int arrLength = 0;
            while (true)
            {
                try
                {
                    string s = jsonObject[theme][arrLength];
                }
                catch
                {
                    break;
                }
                arrLength++;
            }
            return jsonObject[theme][r.Next(arrLength)];//er is een bug waar die het eerste woord van de standard pakt???
        }
        else
        {
            //https://www.c-sharpcorner.com/article/json-serialization-and-deserialization-in-c-sharp/
            string jsonString = File.ReadAllText(String.Format(@"data\{0}", jsonFilename));
            jsonObject = js.Deserialize<dynamic>(jsonString);
            loaded = true;
            return getRandomDescription();
        }
        
    }

    private int overflow(int index, int arrlength) //ik moest een nacht slapen om dit te maken
    {
        if (index >= 0 && index < arrlength)
            return index;
        else
            return overflow(index - arrlength, arrlength);
    }
}


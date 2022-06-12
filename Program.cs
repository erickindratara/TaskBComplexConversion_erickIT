
class Program
{
    public static string isDollar;
    public static string isNegative; 
    
    static void Main(string[] args)
    {
        string isNegative = "";
          isDollar = "";
        bool retry = true;
        while (retry)
        { 
            try
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a Number to convert to currency. ex[$127.45]");
                string number = Console.ReadLine(); 
                number = formattingnumber(number);
                bool isvalid = valid(number);
                number = number.Replace("$", "");
                number = removefrontzero(number);

                if (isvalid )
                {
                    if (number.Contains("-"))
                    { 
                        isNegative = "Minus ";
                        number = number.Substring(1, number.Length - 1);
                    }
                    if (number == "0")
                    {
                        Console.WriteLine("The number in currency format is \nZero Dollar");
                    }
                    else
                    { 
                        Console.WriteLine("The number in currency format is \n{0}", isNegative + ConvertToWords(number));
                    }
                }
                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("exit?(y/n)");
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.KeyChar == 'y' || info.KeyChar == 'Y')
            {
                retry = false;
            }
            else
            {
                retry = true;
            }

        }

    }
    private static string pointsToCent(string number)
    {
        string result = "0"; 
        if (number.Length < 2)
        {
            number = (number + "00").Substring(0, 2);
        }
        int a = 0;
        try { a = Convert.ToInt32(number); } catch (Exception ex){ a = 0; }
        if (number.Length > 0 && a > 0)
        {
            result = "0," + number;
        }
        else
        {
            result = "0";
        }
        decimal b = Convert.ToDecimal(result);
        if (b < Convert.ToDecimal("0,1"))
        {
            result = "0";
        }  
        else
        {
            result = number;
        }

    return result;
    }
    private static String ConvertToWords(String numb)
    {
        String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
        String endStr = "";
        try
        {
            int decimalPlace = numb.IndexOf(".");
            if (decimalPlace > 0)
            {
                wholeNo = numb.Substring(0, decimalPlace);
                points = numb.Substring(decimalPlace + 1);
                if (Convert.ToInt32(points) > 0)
                {
                    andStr = isDollar + " and ";// just to separate whole numbers from points/cents    
                    endStr = "cents " + endStr;//Cents     
                    points = pointsToCent(points);
                    pointStr = ConvertWholeNumber(points);

                }
                else
                {
                    andStr = isDollar + " and ";// just to separate whole numbers from points/cents    
                    endStr = "cents " + endStr;//Cents    
                    points = pointsToCent(points);
                    pointStr = ConvertWholeNumber(points);
                }


            }
            else
            {
                andStr = isDollar;

            }
            val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
        }
        catch { }
        val = val.Replace("  ", " ");
        return val;
    }
    private static String ConvertWholeNumber(String Number)
    {
        string word = "";
        try
        {
            bool beginsZero = false;//tests for 0XX    
            bool isDone = false;//test if already translated    
            double dblAmt = (Convert.ToDouble(Number)); 
            if (dblAmt > 0)
            {//test for zero or digit zero in a nuemric    
                beginsZero = Number.StartsWith("0");

                int numDigits = Number.Length;
                int pos = 0;//store digit grouping    
                String place = "";//digit grouping name:hundres,thousand,etc...    
                switch (numDigits)
                {
                    case 1://ones' range    

                        word = ones(Number);
                        isDone = true;
                        break;
                    case 2://tens' range    
                        word = tens(Number);
                        isDone = true;
                        break;
                    case 3://hundreds' range    
                        pos = (numDigits % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4://thousands' range    
                    case 5:
                    case 6:
                        pos = (numDigits % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7://millions' range    
                    case 8:
                    case 9:
                        pos = (numDigits % 7) + 1;
                        place = " Million ";
                        break;
                    case 10://Billions's range    
                    case 11:
                    case 12:

                        pos = (numDigits % 10) + 1;
                        place = " Billion ";
                        break;
                    //add extra case options for anything above Billion...    
                    default:
                        isDone = true;
                        break;
                }
                if (!isDone)
                {    
                    if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                    {
                        try
                        {
                            string laststring = ConvertWholeNumber(Number.Substring(pos));
                            if (laststring != "" && place != "") { laststring = " and " + laststring; }
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + place + laststring;
                        }
                        catch { }
                    }
                    else
                    {
                        word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                    }    
                } 
                if (word.Trim().Equals(place.Trim())) word = "";
            } 
        }
        catch { }
        return word.Trim();
    } 
    private static String tens(String Number)
    {
        int _Number = Convert.ToInt32(Number);
        String name = null;
        switch (_Number)
        {
            case 10:
                name = "ten";
                break;
            case 11:
                name = "eleven";
                break;
            case 12:
                name = "twelve";
                break;
            case 13:
                name = "thirteen";
                break;
            case 14:
                name = "fourteen";
                break;
            case 15:
                name = "fifteen";
                break;
            case 16:
                name = "sixteen";
                break;
            case 17:
                name = "seventeen";
                break;
            case 18:
                name = "eighteen";
                break;
            case 19:
                name = "nineteen";
                break;
            case 20:
                name = "twenty";
                break;
            case 30:
                name = "thirty";
                break;
            case 40:
                name = "forty";
                break;
            case 50:
                name = "fifty";
                break;
            case 60:
                name = "sixty";
                break;
            case 70:
                name = "seventy";
                break;
            case 80:
                name = "eighty";
                break;
            case 90:
                name = "ninety";
                break;
            default:
                if (_Number > 0)
                {
                    name = tens(Number.Substring(0, 1) + "0") + "-" + ones(Number.Substring(1));
                }
                break;
        }
        return name;
    }

    private static String ones(String Number)
    {
        int _Number = Convert.ToInt32(Number);
        String name = "";
        switch (_Number)
        {

            case 1:
                name = "One";
                break;
            case 2:
                name = "Two";
                break;
            case 3:
                name = "Three";
                break;
            case 4:
                name = "Four";
                break;
            case 5:
                name = "Five";
                break;
            case 6:
                name = "Six";
                break;
            case 7:
                name = "Seven";
                break;
            case 8:
                name = "Eight";
                break;
            case 9:
                name = "Nine";
                break;
        }
        return name;
    }
    static int files(string dirpath, DateTime compareDate, string action)
    {

        string[] filelist = Directory.GetFiles(dirpath, "*.txt");
        string filepath;
        int datafound = 0;
        int datadeleted = 0;
        if (filelist.Count() == 0)
        {
            Console.WriteLine("No file found with filter: [*.txt] AND CreationDate < " + compareDate.ToString() + "");
        }
        else
        {
            for (int i = 0; i < filelist.Count(); i++)
            {
                FileInfo fi = new FileInfo(filelist[i]);
                if (fi.CreationTime < compareDate && fi.Extension == ".txt")
                {
                    datafound = datafound + 1;
                    if (action == "display")
                    {
                        Console.WriteLine("[creation date:" + fi.CreationTime.ToString() + "]" + fi.FullName);
                    }
                    if (action == "delete")
                    {
                        File.Delete(filelist[i]);
                        try
                        {
                            File.Delete(filelist[i]);
                            Console.WriteLine(fi.FullName + ": Deleted");
                            datadeleted = datadeleted + 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(fi.FullName + ": Error occured.");
                        }

                    }
                }
            }
            Console.WriteLine(datafound.ToString() + " File(s) Found. " + datadeleted.ToString() + " File(s) Deleted.");
        }
        return datafound;
    }

    static string formattingnumber(string text)
    {
        string result = "";
        string cent = "";
        text = text.Trim();

        while (text.Contains("."))
        {
            string chars = text.Substring(text.Length - 1, 1);
            if (chars == ".")
            {
                /*skip*/
                text = text.Substring(0, text.Length - 1);
                text = text.Replace(".", "");
            }
            else
            {
                cent = chars + cent;
                text = text.Substring(0, text.Length - 1);
            }
;
        }
        result = text.Replace(",", "");
        result = text.Replace(".", "");
        if (cent.Length > 0)
        {
            result = result + "." + cent;
        }

        return result;


    }
    static bool valid(string number)
    {
        bool valid = true;


        if (valid && number.Substring(0, 1) == "$")
        {
            isDollar = "Dollars";
        }
        else
        {
            valid = false;
            Console.WriteLine("unrecognized currency symbol, you need to input currency symbol. first");
            isDollar = "";
        }
        if (valid && number.Any(x => char.IsLetter(x)))
        {
            valid = false;
            Console.WriteLine("please input number only");
        }

        if (valid && number.Contains(","))
        {
            valid = false;
            Console.WriteLine("a comma(,) need to be removed,[" + number + "] if you want to add cent to your number, please use dot (.)");
        }
        if (valid && number.Length > 15)
        {
            valid = false;
            Console.WriteLine("cannot input more than 15 chars length. ");
        }

        return valid;
    }
    static string removefrontzero(string a)
    {
        string result = "";
        bool loop = true;
        while (a.Substring(0, 1) == "0" && loop)
        {
            if (a.Length > 1)
            {
                a = a.Substring(1, a.Length - 1);
            }
            else
            {
                a = a;
                loop = false;
            }
        }
        result = a;
        return result;
    }
}
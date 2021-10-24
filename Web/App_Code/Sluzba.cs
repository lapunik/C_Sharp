using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Souhrnný popis pro WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Chcete-li povolit volání této webové služby ze skriptu pomocí prvku ASP.NET AJAX, zrušte komentář u následujícího řádku. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Pokud používáte navržené komponenty, zrušte komentář u následujícího řádku. 
        //InitializeComponent(); 
    }

    //zalozeni: novy existujici web do nove slozky, pridat soubor konfigurace, přidar asmx

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello KAE/ASE";
    }

    [WebMethod]
    public int Soucet(int a, int b)
    {
        return a + b; // pro odladeni musim dát F5 na .asmx
    }

    [WebMethod]
    public int Podil(int a, int b)
    {
        return a / b; // deleni nulou pri debugu odhali ale jinak vrati nejakej string s hlaskou chyby primo ve webu
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for Peydav
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Peydav : System.Web.Services.WebService {

    public Peydav () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public string uyeSorgula(int id, string uyeisim, string sifre)
    {
        int sonuc = -1;
        uyeler uyevarmi = new uyeler(id, uyeisim, sifre);
        sonuc = uyevarmi.uyeSorgula(uyevarmi);
        return new JavaScriptSerializer().Serialize(sonuc.ToString());
    }
}

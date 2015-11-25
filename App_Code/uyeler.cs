using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for uyeler
/// </summary>
public class uyeler
{
    public int uyeid { get; set; }
    public string uyeisim { get; set; }
    public string sifre { get; set; }

	public uyeler()
	{
		
	}
    public uyeler(int uyeid, string uyeisim, string sifre)
    {
        this.uyeid = uyeid;
        this.uyeisim = uyeisim;
        this.sifre = sifre;
    }

    public int uyeSorgula(uyeler uye)
    {
        int sonuc = -1;
        try
        {
            Fonksiyon fnk = new Fonksiyon();
            SqlConnection con = fnk.Baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM uyeler Where kullaniciadi='" + uye.uyeisim + "' and sifre='" + uye.sifre + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                sonuc = Convert.ToInt32(dr["id"].ToString());
            }
        }
        catch (Exception)
        {
            throw;
        }
        return sonuc;
    }
}
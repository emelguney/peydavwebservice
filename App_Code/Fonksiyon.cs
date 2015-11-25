using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Fonksiyon
{
    public int SayfaId { get; set; }
    public int UstKategori { get; set; }
    public string Baslik { get; set; }

    public Fonksiyon()
    {

    }
    public SqlConnection Baglan()
    {
        SqlConnection Baglan = new SqlConnection("Data Source=95.173.170.161; Initial Catalog=mustafa7_peydav; User Id=mustafa7_peydav; Password=pZy094o^");

        Baglan.Open();
        return (Baglan);
    }
    public int cmd(string sqlcumle)
    {
        SqlConnection Baglan = this.Baglan();
        SqlCommand cmd = new SqlCommand(sqlcumle, Baglan);
        int sonuc = 0;
        try
        {
            sonuc = cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sqlcumle + ")");
        }
        cmd.Dispose();
        Baglan.Close();
        Baglan.Dispose();
        return (sonuc);
    }
    //public void HataYakala(string HataAdi, string Sayfa)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.Connection = Baglan();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "Sp_HataEkle";
    //    cmd.Parameters.Add("@HataAdi", HataAdi);
    //    cmd.Parameters.Add("@Sayfa", Sayfa);
    //    cmd.Parameters.Add("@EklenmeTarihi", DateTime.Now.ToString());
    //    cmd.Parameters.Add("@Durumu", "0");
    //    cmd.ExecuteNonQuery();
    //}
    public DataTable GetDataTable(string sqlcumleciki)
    {
        SqlConnection Baglan = this.Baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sqlcumleciki, Baglan);
        DataTable dt = new DataTable();
        try
        {
            adapter.Fill(dt);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + "(" + sqlcumleciki + ")");
        }
        adapter.Dispose();
        Baglan.Close();
        Baglan.Dispose();
        return dt;
    }
    public DataRow GetDataRow(string sql)
    {
        DataTable Table = GetDataTable(sql);
        if (Table.Rows.Count == 0) return null;
        return Table.Rows[0];
    }
    public string GetDataCell(string sql)
    {
        DataTable Table = GetDataTable(sql);
        if (Table.Rows.Count == 0) return null;
        return Table.Rows[0][0].ToString();
    }
}
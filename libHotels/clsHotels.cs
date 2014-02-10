﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace libHotels
{
    public class clsHotels
    {

        private string Connection = "Data Source=172.18.98.7;Initial Catalog=SAISIE;Persist Security Info=True;User ID=benjamin;Password=benjamin";

        public DataSet getDureeMax(string villeArrivee, DateTime date)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = Connection;
            MyC.Open();
            SqlDataAdapter MyCom = new SqlDataAdapter("dureeHotel", MyC);
            MyCom.SelectCommand.CommandType = CommandType.StoredProcedure;
            MyCom.SelectCommand.Parameters.Add("@ARRIVEE", SqlDbType.Text);
            MyCom.SelectCommand.Parameters["@ARRIVEE"].Value = villeArrivee;
            MyCom.SelectCommand.Parameters.Add("@DATE", SqlDbType.Date);
            MyCom.SelectCommand.Parameters["@DATE"].Value = date;
            DataSet DataSet = new DataSet();
            MyCom.Fill(DataSet, "DUREE_MAX");
            MyCom.Dispose();
            MyC.Close();
            return DataSet;
        }

        public DataSet getHotels(string VilleA, int Duree, DateTime Date)
        {
            SqlConnection MyC = new SqlConnection();
            MyC.ConnectionString = Connection;
            MyC.Open();
            SqlDataAdapter MyCom = new SqlDataAdapter("listeHotel", MyC);
            MyCom.SelectCommand.CommandType = CommandType.StoredProcedure;
            MyCom.SelectCommand.Parameters.Add("@DUREE", SqlDbType.Int);
            MyCom.SelectCommand.Parameters["@DUREE"].Value = Duree;
            MyCom.SelectCommand.Parameters.Add("@ARRIVEE", SqlDbType.Text);
            MyCom.SelectCommand.Parameters["@ARRIVEE"].Value = VilleA;
            MyCom.SelectCommand.Parameters.Add("@DATE", SqlDbType.Date);
            MyCom.SelectCommand.Parameters["@DATE"].Value = Date;
            DataSet DataSet = new DataSet();
            MyCom.Fill(DataSet, "LISTE_HOTELS");
            MyCom.Dispose();
            MyC.Close();
            return DataSet;
        }
    }
}

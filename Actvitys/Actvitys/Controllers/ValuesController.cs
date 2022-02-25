
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Actvitys.Models;
using Newtonsoft.Json;
using System.Data;


public class ValuesController : ApiController
{


    SqlConnection con = new SqlConnection("server=BHAVNAWKS761;Database=ASSAIGNMENT;  Integrated Security=true;");

    // GET api/values
    public string Get()
    {

        SqlDataAdapter da = new SqlDataAdapter("select * from Actvity", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return JsonConvert.SerializeObject(dt);
        }
        else
        {
            return "Data not Found";
        }

    }
    public string Get(int Id)
    {
        return "value";
    }

    // POST api/values
    public string Post([FromBody] string values)
    {
        SqlCommand cmd = new SqlCommand("insert into Actvity VALUES('" + values + "')", con);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i == 1)
        {

            return " record inserted with values as" + values;
        }
        else
        {
            return "try agin  not   inserted record";
        }
    }

    // PUT api/values/5
    public string Put(int id, [FromBody] string value)
          

    {
        SqlConnection con = new SqlConnection("server=BHAVNAWKS761;Database=ASSAIGNMENT;  Integrated Security=true;");

        SqlCommand cmd = new SqlCommand("updates Actvity set '" + value + "'  WHERE ID'" + id+ "'", con);
        con.Open();
         int  i = cmd.ExecuteNonQuery();
        con.Close();
        if (i == 1)
        {
            return "record update value as" + value + "and  id is" + id;
        }
        else
        {
            return "try  agin.no updated";
        }
    }

    // DELETE api/values/5
    public string Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM Actvity  WHERE ID='" + id + "'", con);
        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i == 1)
        {
            return "record delete value as id is" + id;
        }
        else
        {
            return "try  agin.no delete";
        }
    }
}


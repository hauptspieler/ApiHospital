using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;

namespace testeApi.Controllers
{
    public class ValuesController : ApiController
    {
        static string conexao = ConfigurationManager.ConnectionStrings["bancosql"].ConnectionString;
        private SqlConnection con = new SqlConnection(conexao);
       // GET api/values
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "Nenhum dado encontrado";
            }
        }

        public string Get(int Id)
        {
            //return new string[] { "value1", "value2" };
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy WHERE Idpaciente = " + Id + " ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "Nenhum dado encontrado";
            }
        }

        //  PARA CODIGO DE ULTIMO ATENDIMENTO
        [HttpGet]
        [Route("api/atendimento/{ultimoatend}")]
        public IHttpActionResult atendimento(string ultimoatend)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy WHERE sCodUltimoAtendimento = '" + ultimoatend + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Ok(JsonConvert.SerializeObject(dt));
            }
            else
            {
                return Ok("Nenhum dado encontrado");
            }

        }


        // PARA NOME DE PACIENTE
        [HttpGet]
        [Route("api/paciente/{nomePac}")]
        public IHttpActionResult paciente(string nomePac)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy WHERE sNomePaciente like '%" + nomePac + "%' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Ok(JsonConvert.SerializeObject(dt));
            }
            else
            {
                return Ok("Nenhum dado encontrado");
            }

        }


       
       

        [HttpGet]
        [Route("api/data/{DtCad}")]
        public IHttpActionResult data(string DtCad)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy WHERE dtCadastro ='" + DtCad + "' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Ok(JsonConvert.SerializeObject(dt));
            }
            else
            {
                return Ok("Nenhum dado encontrado");
            }

        }


    






        }
    }

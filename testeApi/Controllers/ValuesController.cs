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

namespace testeApi.Controllers
{
    public class ValuesController : ApiController
    {
        private SqlConnection con = new SqlConnection(@"server=DESKTOP-UR34453\SQLEXPRESS; database=Banco-de-teste; Integrated Security=true;");
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
        [Route("api/data/{date}")]
        public IHttpActionResult data(float date)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbSimulaWebServiceTasy WHERE dtUltimoAtendimento like '%" + date + "%' ", con);
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


        //https://code-maze.com/net-core-web-development-part5/





            [Route("api/data/{date}")]
            [HttpGet]
            public IEnumerable<MyRecordType> GetByDateRange([FromUri] string startDateString, [FromUri] string endDateString)
            {
                var startDate = BuildDateTimeFromYAFormat(startDateString);
                var endDate = BuildDateTimeFromYAFormat(endDateString);
                ...
    }

            
            private DateTime BuildDateTimeFromYAFormat(string dateString)
            {
                Regex r = new Regex(@"^\d{4}\d{2}\d{2}T\d{2}\d{2}Z$");
                if (!r.IsMatch(dateString))
                {
                    throw new FormatException(
                        string.Format(dateString));
                }

                DateTime dt = DateTime.ParseExact(dateString, "yyyyMMddThhmmZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

                return dt;
            }




            //    // POST api/values
            //    public void Post([FromBody] string value)
            //    {
            //    }

            //    // PUT api/values/5
            //    public void Put(int id, [FromBody] string value)
            //    {
            //    }

            //    // DELETE api/values/5
            //    public void Delete(int id)
            //    {
            //    }





        }
    }

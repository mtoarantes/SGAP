using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SGAP.DAL.EntityConfiguration;
using SGAP.DAL.Models.Configuracao;

namespace SGAP.WebApi.Controllers.Configuracoes
{
    public class ConfiguracaoCentroResultadoController : ApiController
    {
        private EntityConfiguration db = new EntityConfiguration();

        // GET: api/ConfiguracaoCentroResultado
        public IQueryable<ConfiguracaoCentroResultado> GetConfiguracaoCentroResultado()
        {
            return db.ConfiguracaoCentroResultado;
        }

        // GET: api/ConfiguracaoCentroResultado/5
        [ResponseType(typeof(ConfiguracaoCentroResultado))]
        public IHttpActionResult GetConfiguracaoCentroResultado(int id)
        {
            ConfiguracaoCentroResultado configuracaoCentroResultado = db.ConfiguracaoCentroResultado.Find(id);
            if (configuracaoCentroResultado == null)
            {
                return NotFound();
            }

            return Ok(configuracaoCentroResultado);
        }

        // PUT: api/ConfiguracaoCentroResultado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfiguracaoCentroResultado(int id, ConfiguracaoCentroResultado configuracaoCentroResultado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuracaoCentroResultado.iCodConfigCentroCusto)
            {
                return BadRequest();
            }

            db.Entry(configuracaoCentroResultado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracaoCentroResultadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ConfiguracaoCentroResultado
        [ResponseType(typeof(ConfiguracaoCentroResultado))]
        public HttpResponseMessage PostConfiguracaoCentroResultado(ConfiguracaoCentroResultado configuracaoCentroResultado)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ocorreu um erro!");
            }

            try
            {
                db.ConfiguracaoCentroResultado.Add(configuracaoCentroResultado);
                db.SaveChanges();
                CreatedAtRoute("DefaultApi", new { id = configuracaoCentroResultado.iCodConfigCentroCusto }, configuracaoCentroResultado);
                return Request.CreateResponse(HttpStatusCode.OK, "Registro inserido com sucesso");
            }
            catch (Exception)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro!");
            }
        }

        // DELETE: api/ConfiguracaoCentroResultado/5
        [ResponseType(typeof(ConfiguracaoCentroResultado))]
        public IHttpActionResult DeleteConfiguracaoCentroResultado(int id)
        {
            ConfiguracaoCentroResultado configuracaoCentroResultado = db.ConfiguracaoCentroResultado.Find(id);
            if (configuracaoCentroResultado == null)
            {
                return NotFound();
            }

            db.ConfiguracaoCentroResultado.Remove(configuracaoCentroResultado);
            db.SaveChanges();

            return Ok(configuracaoCentroResultado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfiguracaoCentroResultadoExists(int id)
        {
            return db.ConfiguracaoCentroResultado.Count(e => e.iCodConfigCentroCusto == id) > 0;
        }
    }
}
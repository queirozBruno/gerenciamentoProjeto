using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Servico.Tabelas;
using Modelo;
using System.Net;

namespace gerenciamentoProjeto.Controllers
{
    public class CertificadoController : Controller
    {
        private CertificadoServico certificadoServico = new CertificadoServico();

        // GET: Certificado
        public ActionResult Index()
        {
            return View(certificadoServico.ObterCertificadosClassificadosPorNome());
        }

        private ActionResult ObterVisaoCertificadoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificado certificado = certificadoServico.ObterCertificadoPorId((long)id);
            if (certificado == null)
            {
                return HttpNotFound();
            }
            return View(certificado);
        }

        ActionResult GravarCertificado(Certificado certificado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    certificadoServico.GravarCertificado(certificado);
                    return RedirectToAction("Index");
                }
                return View(certificado);
            }
            catch
            {
                return View(certificado);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCertificadoPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Certificado certificado)
        {
            return GravarCertificado(certificado);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCertificadoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Certificado certificado)
        {
            return GravarCertificado(certificado);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCertificadoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Certificado certificado = certificadoServico.EliminarCertificadoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
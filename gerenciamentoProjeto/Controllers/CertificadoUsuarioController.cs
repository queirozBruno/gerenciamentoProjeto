using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class CertificadoUsuarioController : Controller
    {
        private CertificadoUsuarioServico certificadoUsuarioServico = new CertificadoUsuarioServico();
        private CertificadoServico certificadoServico = new CertificadoServico();
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: CertificadoUsuario
        public ActionResult Index()
        {
            return View(certificadoUsuarioServico.ObterCertificadoUsuarioClassificadosPorNome());
        }

        private ActionResult ObterVisaoCertificadoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificadoUsuario certificadoUsuario = certificadoUsuarioServico.ObterCertificadoUsuarioPorId((long)id);
            if (certificadoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(certificadoUsuario);
        }

        ActionResult GravarCertificadoUsuario(CertificadoUsuario certificadoUsuario)
        {
            try
            {
                bool verificaCertificado = certificadoServico.VerificaSeCertificadoExiste(certificadoUsuario.certificado.CertificadoNome);
                if (verificaCertificado == false) //Não existe
                {
                    certificadoServico.GravarCertificado(certificadoUsuario.certificado);
                    certificadoUsuario.CertificadoId = certificadoUsuario.certificado.CertificadoId;
                }
                else
                {
                    Certificado certificado = certificadoServico.ObterCertificadoPorNome(certificadoUsuario.certificado.CertificadoNome);
                    certificadoUsuario.CertificadoId = certificado.CertificadoId;
                }
                certificadoUsuario.certificado = null;
                certificadoUsuario.UsuarioId = (long)Session["ID"];
                if (ModelState.IsValid)
                {
                    certificadoUsuarioServico.GravarCertificadoUsuario(certificadoUsuario);
                    return RedirectToAction("Details", "Usuario", null);
                }
                return View(certificadoUsuario);
            }
            catch
            {
                return View(certificadoUsuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCertificadoUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(CertificadoUsuario certificadoUsuario)
        {
            return GravarCertificadoUsuario(certificadoUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCertificadoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(CertificadoUsuario certificadoUsuario)
        {
            return GravarCertificadoUsuario(certificadoUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCertificadoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                CertificadoUsuario certificadoUsuario = certificadoUsuarioServico.EliminarCertificadoUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
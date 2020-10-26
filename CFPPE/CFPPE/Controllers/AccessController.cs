using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CFPPE.Controllers
{
    public class AccessController : Controller
    {
        string urlDomain = "http://localhost:51120/";
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StartRecovery()
        {
            Models.ViewModel.RecoveryViewModel model = new Models.ViewModel.RecoveryViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult StartRecovery(Models.ViewModel.RecoveryViewModel model)
        {            
                try
                {

                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }

                    string token = GetSha256(Guid.NewGuid().ToString());

                    using (Models.plataformaEntities db = new Models.plataformaEntities())
                    {
                        var oUser = db.usuario.Where(d => d.Correo == model.Email).FirstOrDefault();
                        if (oUser != null)
                        {
                            oUser.TokenRecovery = token;
                            db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                        //enviamos email
                        SendEmail(oUser.Correo,token);
                        }
                    }
                    return View();
                }
                catch (Exception es)
                {
                    throw new Exception(es.Message);
                }
            }

        [HttpGet]
        public ActionResult Recovery(string token)
        {
            Models.ViewModel.RecoveryPasswordViewModel model = new Models.ViewModel.RecoveryPasswordViewModel ();
            model.token = token;
            using (Models.plataformaEntities db = new Models.plataformaEntities())
            {
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View("Index", "Logueo");
                }
                var oUser = db.usuario.Where(d => d.TokenRecovery == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Token incorrecto contacte al administrador";
                    return View("Index","Logueo");
                }
            }
          
            return View(model);
        }
        [HttpPost]
        public ActionResult Recovery(Models.ViewModel.RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (Models.plataformaEntities db = new Models.plataformaEntities())
                {
                    var oUser = db.usuario.Where(d => d.TokenRecovery == model.token).FirstOrDefault();

                    if (oUser != null)
                    {
                        oUser.Contraseña = model.Password;
                        oUser.TokenRecovery = null;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            ViewBag.Message = "Contraseña modificada con exito";
            return View("Index","Logueo");
        }

        #region HELPERS
        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding enconding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(enconding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
                
        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "jhonn.94gs@gmail.com";
            string Contraseña = "JGZ_7N*94";
            string url = urlDomain+"/Access/Recovery/?token="+token; 
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de contraseña",
            "<p>Correo para recuperar su contraseña</p><br>" +
            "<a href='"+url+"'>Click para recuperarla<a/>");
            

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
        }

        #endregion
    }
}
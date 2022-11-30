using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyecto_aula.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime;
using System.IO.Compression;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
//Nueva Librerias
using iTextSharp.tool.xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources.Extensions;

namespace proyecto_aula.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextoBasededatos _context;
        private ClaimsPrincipal principal;
        private readonly IWebHostEnvironment _hostEnviroment;

        public HomeController(ILogger<HomeController> logger, ContextoBasededatos context, IWebHostEnvironment HostEnvironment)
        {
            _logger = logger;
            _context = context;
            _hostEnviroment = HostEnvironment;
        }
        //***************************************************************REGISTRAR AL USUARIO******************************************************************
        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            ViewBag.Error = String.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Completo = String.IsNullOrEmpty(HttpContext.Request.Query["completo"]) ? false : true;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult RegistrarUsuario([Bind("UsuarioID,Correo,Imagenp,Password,Nombre,ApellidoP,ApellidoM,FechaAlta,FechaUltimaActualizacion,Estado")] Usuario usuario)
        {
            try
            {
                var Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == usuario.UsuarioID);
                if (Usuario != null)
                {
                    return RedirectToAction("RegistrarUsuario", new {error=true}) ;
                }
                else
                {
                    usuario.FechaAlta = DateTime.Now.ToString();
                    usuario.FechaUltimaActualizacion = DateTime.Now.ToString();
                    usuario.Imagenp = "sin_perfil.jpg";
                    usuario.Password = proyecto.Encriptar.EncriptarPassword(usuario.Password);
                    usuario.Estado = true;
                    //if (ModelState.IsValid)

                    //{
                    _context.Add(usuario);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                    //}
                    //else
                    //{
                    //  return RedirectToAction("RegistrarUsuario", new { error = true });
                    //}
                }
            }

            catch(Exception ex)
            {
                return RedirectToAction("RegistrarUsuario", new { error = true });
            }

        }
        //***************************************************************************************************************************************************//
        //************************************lOGIN BIBLIOTECARIO USUARIOS ********************************************************************************//
        public IActionResult Login()
        {
            ViewBag.Error = string.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Error = String.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Completo = String.IsNullOrEmpty(HttpContext.Request.Query["completo"]) ? false : true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(int boleta, string pass)
        {
            var Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == boleta);
            if (Usuario == null)
            {
                return RedirectToAction("Login", new { error = true });
            }
            if (Usuario.Password != proyecto.Encriptar.EncriptarPassword(pass))
            {
                return RedirectToAction("Login", new { error = true });
            }
            if (Usuario.Estado == false)
            {
                return View("Bloqueado", Usuario);
            }
            List<Claim> autorizacion = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,Usuario.Nombre),
                new Claim(ClaimTypes.Email,Usuario.Correo),
                new Claim(ClaimTypes.Role,"Usuario"),
                new Claim("UsuarioID", Usuario.UsuarioID.ToString()),
                new Claim("Autenticado","SI"),

            };
            var identidad = new ClaimsIdentity(autorizacion, "AutorizacionesClaim");
            var principal = new ClaimsPrincipal(new[] { identidad });
            Usuario.FechaUltimaActualizacion = DateTime.Now.ToString();
            _context.Update(Usuario);
          await HttpContext.SignInAsync(principal);

            return RedirectToAction("Miperfil");
        }
        //***************************************************************************************************************************************************//

        //************************************lOGIN BIBLIOTECARIO SECCION**************************************///
        [HttpGet]
        public IActionResult LoginBiblio()
        {
            ViewBag.Error = string.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Error = String.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Completo = String.IsNullOrEmpty(HttpContext.Request.Query["completo"]) ? false : true;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> LoginBiblio(string Correo, string password)
        {
            var Usuario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == Correo);
            if (Usuario == null)
            {
                return RedirectToAction("LoginBiblio", new { error = true });
            }
            if (Usuario.Password != proyecto.Encriptar.EncriptarPassword(password))
            {
                return RedirectToAction("LoginBiblio", new { error = true });
            }
            List<Claim> autorizacion = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,Usuario.Nombre),
                new Claim(ClaimTypes.Email,Usuario.Correo),
                new Claim(ClaimTypes.Role,"Bibliotecario"),
                new Claim("BiblioID", Usuario.BiblioID.ToString()),
                new Claim("Autenticado","SI"),

            };
            var identidad = new ClaimsIdentity(autorizacion, "AutorizacionesClaim");
            var principal = new ClaimsPrincipal(new[] { identidad });
            Usuario.FechaUltimaActualizacion = DateTime.Now.ToString();
            _context.Update(Usuario);
           await HttpContext.SignInAsync(principal);

            return RedirectToAction("PerfilBiblio");
        }
        //***************************************************************************************************************************************************//
        //******************************************************Cosas que podrian servir******************************************************************//
        [Authorize]
        public IActionResult perfil()
        {
            return View(User?.Claims);
        }
        public async Task<IActionResult> SingOut()
        {
           await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public async Task< IActionResult> SingOut2()
        {
           await HttpContext.SignOutAsync();
            return RedirectToAction("LoginBiblio");
        }
        [HttpPost]
        public IActionResult CambiarIm(IFormFile Imagen)
        {
            try
            {
                string wwwRootPath = Path.Combine(_hostEnviroment.WebRootPath, "Perfil");
                string carpeta = DateTime.Now.ToString("yymmdd");
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                var usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                usuario.Imagenp = Path.Combine(Guid.NewGuid() + Path.GetExtension(Imagen.FileName));
                if (!Directory.Exists(Path.Combine(wwwRootPath, carpeta))) Directory.CreateDirectory(Path.Combine(wwwRootPath, carpeta));
                using (var fstream = new FileStream(Path.Combine(wwwRootPath, usuario.Imagenp), FileMode.Create))
                {
                    Imagen.CopyTo(fstream);
                }
                _context.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Miperfil");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Miperfil", new { error = true });
            }
        }
        public IActionResult CambiarIm2(IFormFile Imagen)
        {
            try
            {
                string wwwRootPath = Path.Combine(_hostEnviroment.WebRootPath, "ImagenPB");
                string carpeta = DateTime.Now.ToString("yymmdd");
                var BiblioID = User.Claims.FirstOrDefault(p => p.Type == "BiblioID").Value;
                var usuario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == BiblioID);
                usuario.Imagenp = Path.Combine(Guid.NewGuid() + Path.GetExtension(Imagen.FileName));
                if (!Directory.Exists(Path.Combine(wwwRootPath, carpeta))) Directory.CreateDirectory(Path.Combine(wwwRootPath, carpeta));
                using (var fstream = new FileStream(Path.Combine(wwwRootPath, usuario.Imagenp), FileMode.Create))
                {
                    Imagen.CopyTo(fstream);
                }
                _context.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("PerfilBiblio");
            }
            catch (Exception ex)
            {
                return RedirectToAction("PerfilBiblio", new { error = true });
            }
        }
        //**************************************************************************///
        //***************************************************SECCION DE POST************************************//
        [Authorize(Roles = "Usuario")]
        public IActionResult Post()
        {
            Usuario nuevo = new Usuario();
            var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
            ViewBag._Post = _context.Post.Where(p => UsuarioID == p.UsuarioID).ToList();
            ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
            ViewBag._Nombre = _context.Usuario.FirstOrDefault(u => u.Nombre == "UsuarioID");
            ViewBag._Fechapublicacion = _context.Post.FirstOrDefault(p => p.FechaAlta == DateTime.Now);
            return View("Post");
        }
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public IActionResult Agregarpost(string comentario)
        {
            var publicacion = new Post();
            Usuario nuevo = new Usuario();
            var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
            // var UsuarioID = ClaimsPrincipal.Current.Claims.Where(c => c.Type == "UsuarioID").FirstOrDefault();
            publicacion.UsuarioID = UsuarioID;
            publicacion.Comentario = comentario;
            publicacion.FechaAlta = DateTime.Now;
            ValidationContext val = new ValidationContext(publicacion, null, null);
            List<ValidationResult> errores = new List<ValidationResult>();
            Validator.TryValidateObject(publicacion, val, errores);
            if (errores.Count == 0)
            {
                _context.Add(publicacion);
                _context.SaveChanges();
                return RedirectToAction("Post", new { error = false });
            }
            return RedirectToAction("Post", new { error = true });
        }
        //*******************************************************************************************************************//

        //******REGISTRAR LIBROS EN LA BASE DE DATOS*************************************************//

        //************************************************//


        //*************************************REGISTRAR AL BIBLIOTECARIO*****************************************************************************************
        [HttpGet]
        public IActionResult registrar()
        {
            ViewBag.Error = String.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
            ViewBag.Completo = String.IsNullOrEmpty(HttpContext.Request.Query["completo"]) ? false : true;
            return View();
        }

        [HttpPost]
        public IActionResult registrar([Bind("BiblioID,Correo,Imagenp,Password,Nombre,ApellidoP,ApellidoM,Edad,Sexo,FechaAlta,FechaUltimaActualizacion,Estado")] Bibliotecario usuario)
        {
            try
            {
                var Usuario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID== usuario.BiblioID);
                if (Usuario != null)
                {
                    return RedirectToAction("registrar", new { error = true });
                }

                usuario.FechaAlta = DateTime.Now.ToString();
                usuario.FechaUltimaActualizacion = DateTime.Now.ToString();
                usuario.Imagenp = "sin_perfil.jpg";
                //usuario.ApellidoM = "abcd";
                //usuario.ApellidoP = "abcdef";
                usuario.Password = proyecto.Encriptar.EncriptarPassword(usuario.Password);
                usuario.Estado = true;
                // if (ModelState.IsValid)

                //{
                _context.Add(usuario);
                _context.SaveChanges();
                //}
                return RedirectToAction("LoginBiblio");
        }
            catch(Exception ex)
            {
                return RedirectToAction("registrar", new { error = true });
            }

        }
        //**************************************************************************************************
        [Authorize(Roles = "Usuario")]
        public IActionResult MenuUsuario() => View();
        public IActionResult MenuBibliotecario() => View();
        public IActionResult BiblioIndex() => View();


        // //*******************************PRESTAMOS SECCION***********************************************
        [Authorize(Roles = "Usuario")]
        [HttpGet]
        public IActionResult Solicitarprestamo(string opcion)
        {
            ViewBag.Busqueda = _context.Libro.Where(u => u.NomLib.Contains(opcion)).ToList();
            ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente").ToList();
            //var LibroID = Convert.ToInt32(User.Claims.FirstOrDefault(u => u.Type == "LibroID").Value);
            //ViewBag.Libro = _context.Libro.FirstOrDefault(l => l.LibroID == LibroID);
            var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
            ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
            return View();
        }
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public IActionResult Solicitarprestamo([Bind("PrestamoID,NumPres,NomLib,FechaInicio,Fechadevol,Estado,[Usuario ID],[Libro ID],[Biblio ID]")] Prestamo Solicitud, string NombLib, int Numerodeboleta, int idLibro)
        {
           // try
            //{
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                Solicitud.NomLib = NombLib;
                Solicitud.NumPres = Solicitud.NumPres + 1;
                Solicitud.FechaInicio = DateTime.Now;
                Solicitud.Fechadevol = Solicitud.FechaInicio.AddDays(15);
                Solicitud.Estado = "Pendiente";
                Solicitud.UsuarioI = Numerodeboleta;
                Solicitud.Fichapdf = Solicitud.UsuarioI.ToString() + Solicitud.NumPres.ToString();
                Solicitud.LibroI = idLibro;
                Solicitud.BibliotecarioI = "2020131971";
                _context.Prestamo.Add(Solicitud);
                _context.SaveChanges();
                ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.Aprobado = _context.Prestamo.Where(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.Generado = _context.Prestamo.Where(p => p.Estado == "Generado" && p.UsuarioI == UsuarioID).ToList();
                return View("Regresar", Solicitud);
          //  }
            //catch(Exception ex)
            //{
            //    return View("Errores",1);
            //}


        }
        [Authorize(Roles = "Usuario")]
        [HttpGet]
        public IActionResult Confirmacion()
        {
            try
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.Aprobado = _context.Prestamo.Where(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.Generado = _context.Prestamo.Where(p => p.Estado == "Generado" && p.UsuarioI == UsuarioID).ToList();
                return View();
            }
            catch(Exception ex)
            {
                return View("Errores",1);
            }
        }
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public IActionResult Confirmacion(string Usuarioid, string PrestamoID,string Noml,string LibroI)
        {
            var Aprueba = _context.Prestamo.FirstOrDefault(p => p.PrestamoID == Convert.ToInt32(PrestamoID));
            if (Aprueba != null)
            {
                Aprueba.Estado = "Generado";
                Aprueba.Fichapdf = Usuarioid + PrestamoID;
                _context.Prestamo.Update(Aprueba);
                _context.SaveChanges();

                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                var datos = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                string paginahtml_texto = Properties.Resources.Plantilladef;
                paginahtml_texto = paginahtml_texto.Replace("@COMPROBANTE", PrestamoID);
                paginahtml_texto = paginahtml_texto.Replace("@DOCUMENTO", "Ficha de prestamo");
                paginahtml_texto = paginahtml_texto.Replace("@FECHA", DateTime.Now.ToShortDateString());
                paginahtml_texto = paginahtml_texto.Replace("@NOMBRE",datos.Nombre);
                paginahtml_texto = paginahtml_texto.Replace("@APELLIDOP", datos.ApellidoP);
                paginahtml_texto = paginahtml_texto.Replace("@APELLIDOM", datos.ApellidoM);
                paginahtml_texto = paginahtml_texto.Replace("@NombL", Noml);
                paginahtml_texto = paginahtml_texto.Replace("@Devolucion", DateTime.Now.AddDays(15).ToShortDateString()); 
                paginahtml_texto = paginahtml_texto.Replace("@IDLIBRO", LibroI);
                paginahtml_texto = paginahtml_texto.Replace("@USUARIO", UsuarioID.ToString());
                paginahtml_texto = paginahtml_texto.Replace("@PRESTAMOID", PrestamoID);
                string RutaDelarchivo = Path.Combine(_hostEnviroment.WebRootPath, "Fichas/", Usuarioid + PrestamoID+ ".pdf");
                using (FileStream stream = new FileStream(RutaDelarchivo,FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.Easybook_LogoAzul, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 80);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);
                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                }
               //*******************ESPACIO QR*******************************

                Document qr = new Document(PageSize.A4);
                string Rutadelarchivo = Path.Combine(_hostEnviroment.WebRootPath, "QRS/", UsuarioID + PrestamoID + ".pdf");
                PdfWriter.GetInstance(qr, new FileStream(Rutadelarchivo,FileMode.Create));
                qr.Open();
                 BarcodeQRCode barcodeQRCode = new BarcodeQRCode("https://proyecto-aula-qa3.conveyor.cloud/Home/MostrarF?I="+PrestamoID, 1000, 1000, null);
                //BarcodeQRCode barcodeQRCode = new BarcodeQRCode("http://localhost:12974/Home/MostrarF?I=" + PrestamoID, 1000, 1000, null);
                iTextSharp.text.Image codeQRImage = barcodeQRCode.GetImage();
                codeQRImage.ScaleAbsolute(500, 500);
                qr.Add(codeQRImage);
                qr.Close();
                return Mostrar(Usuarioid, PrestamoID);
            }
            else
                return View();
        }

        //************************************************************************************************************


        //******************************************BUSCAR LIBRO EN NUESTRA BASE DE DATOS******************************************************************
        [Authorize(Roles = "Usuario")]
        public IActionResult BuscarLibro() => View();
        [Authorize(Roles = "Usuario")]
        [HttpGet]
        public IActionResult BuscarLibro(string nombre, string Editorial,string Genero)
        {
            try
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                ViewData["NombreLibroID"] = new SelectList(_context.Libro, "NomLib", "NomLib");
                ViewData["GeneroLibroID"] = new SelectList(_context.Libro, "Genero", "Genero");
                ViewData["EditorialLibroID"] = new SelectList(_context.Libro, "Editorial", "Editorial");
                ViewBag._Libros = _context.Libro.ToList();
                ViewBag.Busqueda = _context.Libro.Where(u => u.NomLib.Contains(nombre) && u.Editorial.Contains(Editorial) && u.Genero.Contains(Genero) || u.NomLib.Contains(nombre) || u.Editorial.Contains(Editorial) || u.Genero.Contains(Genero) || u.NomLib.Contains(nombre) && u.Genero.Contains(Genero) || u.Editorial.Contains(Editorial) && u.Genero.Contains(Genero) || u.NomLib.Contains(nombre) && u.Genero.Contains(Editorial)).ToList();
                ViewBag.Busqueda2 = _context.Libro.Where(l => l.NomLib.Contains(Editorial)).ToList();
                return View();
            }
            catch (Exception ex)
            {
                return View("Errores", 1);
            }
        }
        [Authorize(Roles = "Usuario")]
        public IActionResult Miperfil()
        {
            try
            {
                ViewBag.Error = String.IsNullOrEmpty(HttpContext.Request.Query["error"]) ? false : true;
                ViewBag.Completo = String.IsNullOrEmpty(HttpContext.Request.Query["completo"]) ? false : true;
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                return View();
            }
            catch (Exception ex)
            {
                return View("Errores", 1);
            }
        }
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public IActionResult Miperfil(string correo)
        {
            try
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                var usuario = _context.Usuario.FirstOrDefault(u => u.Correo == correo);
                ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                return View();
            }
            catch (Exception ex)
            {
                return View("Errores", 1);
            }

        }


        public IActionResult Index()
        {
            return View();
        }



        //[HttpGet]
        //[Authorize(Roles = "Usuario")]
        //public IActionResult Mostrar(Prestamo pres)
        //{
        //    var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
        //    ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente" && p.UsuarioI == UsuarioID).ToList();
        //    ViewBag.aprobado = _context.Prestamo.Where(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID).ToList();
        //    ViewBag.Generado = _context.Prestamo.Where(p => p.Estado == "Generado" && p.UsuarioI == UsuarioID).ToList();
        //    return View();
        //}

        [HttpGet]
        [Authorize(Roles = "Usuario")]
        public FileResult Mostrar(string IDusuario, string a)
        {
            try
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.aprobado = _context.Prestamo.Where(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID).ToList();
                ViewBag.Generado = _context.Prestamo.Where(p => p.Estado == "Generado" && p.UsuarioI == UsuarioID).ToList();

                string Rutadelarchivo = Path.Combine(_hostEnviroment.WebRootPath, "QRS/", UsuarioID + a + ".pdf");
                if (System.IO.File.Exists(Rutadelarchivo))
                {

                    FileStream archivomuestra = new FileStream(Rutadelarchivo, FileMode.Open);

                    return File(archivomuestra, "application/pdf");
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //[HttpGet]
        //public IActionResult MostrarF()
        //{
        //    var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
        //    //var PrestamoID = Convert.ToInt32(User.Claims.FirstOrDefault(P => P.Type == "PrestamoID").Value);
        //    ViewBag.aprobado = _context.Prestamo.Where(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID).ToList();
        //    return View();
        //}

        [HttpGet]
        [Authorize(Roles = "Usuario")]
        public FileResult MostrarF(string I)
        {
            try
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                var fichas = _context.Prestamo.FirstOrDefault(p => p.Estado == "Aprobado" && p.UsuarioI == UsuarioID);
                ViewBag._Usuario = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                var datos = _context.Usuario.FirstOrDefault(u => u.UsuarioID == UsuarioID);
                string Rutadelarchivo = Path.Combine(_hostEnviroment.WebRootPath, "Fichas/", UsuarioID.ToString() + I + ".pdf");
                if (System.IO.File.Exists(Rutadelarchivo))
                {

                    FileStream archivomuestra = new FileStream(Rutadelarchivo, FileMode.Open);

                    return File(archivomuestra, "application/pdf");
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        //************************************************************************************
        public IActionResult Informacion()
        {
            return View();
        }

        public IActionResult Conversacion()
        {
            string Lista = string.Empty;
            var con = User.Claims.ToArray();
            for(int i = 0; i < con.Length; i++)
            {
                Lista = con[2].ToString();
            }
            if (Lista == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role: Usuario")
            {
                var UsuarioID = Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "UsuarioID").Value);
                ViewBag.Tipo = "Usuario";
                ViewBag.Informacion = _context.Usuario.FirstOrDefault(u=>u.UsuarioID==UsuarioID);
            }
            if (Lista == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role: Bibliotecario")
            {
                var BiblioID = User.Claims.FirstOrDefault(b => b.Type == "BiblioID").Value;
                ViewBag.Tipo = "Bibliotecario";
                ViewBag.Informacion = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == BiblioID);
            }

            return View();
        }


        //[HttpPost]
        //[Authorize(Roles = "Bibliotecario")]
        //public IActionResult Room()
        //{
        //    var BiblioID = User.Claims.FirstOrDefault(u => u.Type == "BiblioID").Value;
        //    ViewBag._Bibliotecario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == BiblioID);
        //    return View("Room");
        //}

        //*****************************+
        //Funciones para los bibliotecarios
        [Authorize(Roles = "Bibliotecario")]
        [HttpGet]
        public IActionResult EditarUsuario()
        {
            ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
            ViewBag._Usuarios = _context.Usuario.ToList();
            ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult Entrgado()
        {
            ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
            ViewBag._Usuarios = _context.Usuario.ToList();
            ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult Entregar()
        {
            ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
            ViewBag._Usuarios = _context.Usuario.ToList();
            ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        public IActionResult Entregar(string PrestamoID, Prestamo prestamo)
        {
            var Aprueba = _context.Prestamo.FirstOrDefault(p => p.PrestamoID == Convert.ToInt32(PrestamoID));
            if (Aprueba != null)
            {
                ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
                ViewBag._Usuarios = _context.Usuario.ToList();
                ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
                Aprueba.Estado = "Entregado";
                _context.Prestamo.Update(Aprueba);
                _context.SaveChanges();
                return View("Entrgado", prestamo);
            }
            return View("Entregado", prestamo);
        }
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult Bloquear()
        {
            ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
            ViewBag._Usuarios = _context.Usuario.ToList();
            ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        public IActionResult Bloquear(string UsuarioID, Prestamo pres)
        {
            var Aprueba = _context.Usuario.FirstOrDefault(u => u.UsuarioID == Convert.ToInt32(UsuarioID));
            if (Aprueba != null)
            {
                if (Aprueba.Estado == false)
                {
                    return View("Bloque", pres);
                }
                ViewBag._Entregados = _context.Prestamo.Where(p => p.Estado == "Entregado").ToList();
                ViewBag._Usuarios = _context.Usuario.ToList();
                ViewBag._PrestamosV = _context.Prestamo.Where(p2 => p2.Estado == "Generado").ToList();
                Aprueba.Estado = false;
                _context.Update(Aprueba);
                _context.SaveChanges();
                return View("Bloquear", pres);
            }
            return View("Index");
        }
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult Desbloquear(Usuario us)
        {
            ViewBag._Usuarios = _context.Usuario.ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        public IActionResult Desbloquear(string UsuarioID)
        {
            var Aprueba = _context.Usuario.FirstOrDefault(u => u.UsuarioID == Convert.ToInt32(UsuarioID));
            if (Aprueba != null)
            {
                Aprueba.Estado = true;
                _context.Update(Aprueba);
                _context.SaveChanges();
                return View("Desbloq");
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult SeleccionarFicha(string id, string a)
        {
            ViewBag.BusquedaF = _context.Prestamo.Where(p => p.Fichapdf.Contains(id)).ToList();
            return View();
        }
        [HttpPost]
        public FileResult SeleccionarFicha(string Ficha)
        {
            var Valor = _context.Prestamo.FirstOrDefault(D => D.Fichapdf == Ficha);
            string Rutadelarchivo = Path.Combine(_hostEnviroment.WebRootPath, "Fichas/", Ficha + ".pdf");
            if (System.IO.File.Exists(Rutadelarchivo))
            {

                FileStream archivomuestra = new FileStream(Rutadelarchivo, FileMode.Open);

                return File(archivomuestra, "application/pdf");
            }
            return null;
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        public IActionResult EditarUsuario(string usuario, string Estado)
        {
            ViewBag._Usuario = _context.Usuario.ToList();
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult RegistrarLibro() => View();
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult RegistrarLibro([Bind("LibroID,NomLib,Editorial,NomAut,ApePaut,ApeMaut,Genero,NumPaginas,AñoEdicion")] Libro libro, IFormFile Imagen)
        {

            string wwwRootPath = Path.Combine(_hostEnviroment.WebRootPath,"Portada");
            string carpeta = DateTime.Now.ToString("yymmdd");
            libro.Portada = Path.Combine(Guid.NewGuid() + Path.GetExtension(Imagen.FileName));
            if (!Directory.Exists(Path.Combine(wwwRootPath, carpeta))) Directory.CreateDirectory(Path.Combine(wwwRootPath, carpeta));
            using (var fstream = new FileStream(Path.Combine(wwwRootPath,libro.Portada), FileMode.Create))
            {
                Imagen.CopyTo(fstream);
            }
            _context.Add(libro);
            _context.SaveChanges();
                return RedirectToAction("RegistrarLibro", libro);
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpGet]
        public IActionResult AprobarPrestamo(string opcion)
        {
            ViewBag.Usuario = _context.Prestamo.Where(U => U.Estado == "Pendiente" && U.UsuarioI.ToString().Contains(opcion)).ToList();
            var BiblioID = User.Claims.FirstOrDefault(u => u.Type == "BiblioID").Value;
            ViewBag._Bibliotecario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == BiblioID);
            ViewBag.Estado = _context.Prestamo.Where(p => p.Estado == "Pendiente").ToList();
            return View();
        }
        [Authorize(Roles = "Bibliotecario")]
        [HttpPost]
        public IActionResult AprobarPrestamo(string BiblioID, int id)
        {
            var Aprueba = _context.Prestamo.FirstOrDefault(p => p.PrestamoID == id);
            if (Aprueba != null)
            {
                Aprueba.Estado = "Aprobado";
                Aprueba.BibliotecarioI = BiblioID;
                _context.Prestamo.Update(Aprueba);
                _context.SaveChanges();
            }
            return RedirectToAction("AprobarPrestamo");
        }

        [Authorize(Roles = "Bibliotecario")]
        public IActionResult PerfilBiblio()
        {
            try
            {
                var BiblioID = User.Claims.FirstOrDefault(u => u.Type == "BiblioID").Value;
                ViewBag._Bibliotecario = _context.Bibliotecario.FirstOrDefault(u => u.BiblioID == BiblioID);
                return View();
            }
            catch (Exception ex)
            {
                return View("Index");
            }
        }

        //****************************************
        [Authorize(Roles = "Bibliotecario")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}


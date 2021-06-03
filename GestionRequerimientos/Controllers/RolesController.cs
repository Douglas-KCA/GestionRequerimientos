using GestionRequerimientos.Models;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GestionRequerimientos.Controllers
{
    public class RolesController : Controller
    {
        private RequerimientosContext context = new RequerimientosContext();
        // GET: Roles
        public ActionResult Index()
        {
            var listado = context.ROL;
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ROL rol)
        {
            if ((rol.rol1 != "") && (rol.descripcion != ""))
            {
                context.ROL.Add(rol);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            /*
            var viewmodel = new ProyectoViewModel();
            viewmodel.proyecto = context.PROYECTO.FirstOrDefault(x => x.id_proyecto == id);
            viewmodel.Estados = context.ESTADO.ToList();
            */
            var listado = context.ROL.FirstOrDefault(x => x.id_rol == id);
            return View(listado);
        }

        [HttpPost]
        public ActionResult Actualizar(ROL rol)
        {
            if ((rol.rol1 != "") && (rol.descripcion != ""))
            {
                context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Reporte()
        {
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pfdDocument = new PdfDocument(pw);
            Document doc = new Document(pfdDocument, PageSize.LETTER);
            doc.SetMargins(75, 35, 70, 35);

            iText.Layout.Element.Table table = new iText.Layout.Element.Table(1).UseAllAvailableWidth();
            Cell cell = new Cell().Add(new Paragraph("Reporte de Roles").SetFontSize(14))
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetBorder(Border.NO_BORDER);
            table.AddCell(cell);
            /*
            cell = new Cell().Add(new Paragraph("Roles Adminstrativos"))
                  .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                  .SetBorder(Border.NO_BORDER);
            table.AddCell(cell);
            */
            doc.Add(table);

            iText.Layout.Style styleCell = new iText.Layout.Style()
                .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                .SetTextAlignment(TextAlignment.CENTER);

            iText.Layout.Element.Table _table = new iText.Layout.Element.Table(4).UseAllAvailableWidth(); ;
            Cell _cell = new Cell(2, 1).Add(new Paragraph("#"));
            _table.AddHeaderCell(_cell.AddStyle(styleCell));
            _cell = new Cell().Add(new Paragraph("Rol"));
            _table.AddHeaderCell(_cell.AddStyle(styleCell));
            _cell = new Cell().Add(new Paragraph("Descripcion"));
            _table.AddHeaderCell(_cell.AddStyle(styleCell));
            _cell = new Cell().Add(new Paragraph("Estado"));
            _table.AddHeaderCell(_cell.AddStyle(styleCell));

            List<ROL> model = context.ROL.ToList();

            
            foreach (var item in model)
            {
                _cell = new Cell().Add(new Paragraph(item.id_rol.ToString()));
                _table.AddCell(_cell);
                _cell = new Cell().Add(new Paragraph(item.rol1.ToString()));
                _table.AddCell(_cell);
                _cell = new Cell().Add(new Paragraph(item.descripcion.ToString()));
                _table.AddCell(_cell);

                if(item.estado.ToString() == "1")
                    _cell = new Cell().Add(new Paragraph("ACTIVO"));
                else
                    _cell = new Cell().Add(new Paragraph("INACTIVO"));

                _table.AddCell(_cell);
            }

            doc.Add(_table);

            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;

            return new FileStreamResult(ms, "application/pdf");
        }
    }
}




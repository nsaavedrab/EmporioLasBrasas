using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BarCode.Models
{
    
    public class BarCodeModel
    {
        public string BarCode { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public int Precio { get; set; }
        public string Peso { get; set; }
        public decimal Total{ get; set; }
        public BarCodeModel()
        {
            
        }

        public void GenerateBarCode()
        {
            BarcodeLib.Barcode codigo = new BarcodeLib.Barcode();
            codigo.IncludeLabel = false;
            string Data;

            if (Peso == null)
            {
                Data = Codigo;
            }
            else
            {
                Data = Codigo + "0" + String.Format("{0:-00000}", Peso.ToString().Replace(",", "").Replace(".", ""));
            }
            
            var imagen = codigo.Encode(BarcodeLib.TYPE.CODE128, Data, System.Drawing.Color.Black, System.Drawing.Color.White, 300, 60);

            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                var base64 = Convert.ToBase64String(imageBytes);
                BarCode = String.Format("data:image/png;base64,{0}", base64);

                if (Peso == null)
                {
                    Total = Precio;
                }
                else
                {
                    Total = decimal.Round(Precio * Decimal.Parse(Peso.ToString().Replace(".", ",")), 0, MidpointRounding.AwayFromZero);
                }
                
            }
        }
    }



}
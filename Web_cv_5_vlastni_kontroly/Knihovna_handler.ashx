<%@ WebHandler Language="C#" Class="Knihovna_handler" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using ase_knihovna;

public class Knihovna_handler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {

        int height = 256;
        int width = 128;


        foreach (string key in context.Request.QueryString.Keys)
        {
            switch (key)
            {
                case "w":
                    if (!int.TryParse(context.Request.QueryString[key], out width))
                    {
                        width = 256;
                    }
                    break;

                case "h":
                    if (!int.TryParse(context.Request.QueryString[key], out height))
                    {
                        height = 1400;
                    }
                    break;
            }
        }

        context.Response.ContentType = "image/png";

        using (Bitmap bitmap = new Bitmap(256, 128))
        {

            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {

                Kreslic.Kresli(graphics, rectangle);

            }

            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
        }


    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}
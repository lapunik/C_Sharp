<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public class Handler : IHttpHandler
{

    public void ProcessRequest (HttpContext context)
    {
        // context.Response.ContentType = "text/plain"; // typ 
        // context.Response.Write("Hello ASE"); 

        context.Response.ContentType = "image/png";

        using (Bitmap bitmap = new Bitmap(256, 128))
        {

            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {

            graphics.FillRectangle(Brushes.DodgerBlue, rectangle);
            graphics.FillEllipse(Brushes.LightGray, rectangle);

            }

            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
        }



    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
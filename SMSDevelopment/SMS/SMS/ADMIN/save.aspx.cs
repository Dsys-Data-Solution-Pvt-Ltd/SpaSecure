using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SMS.ADMIN
{
    public partial class save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var data = Request.BinaryRead(Request.TotalBytes);
                System.Drawing.Image im = byteArrayToImage(data);
                string path = "Images/" + System.Guid.NewGuid().ToString().Split('-')[System.Guid.NewGuid().ToString().Split('-').Length - 1] + ".jpg";
                im.Save(Server.MapPath(path));
                Session["CaptureImage"] = path;
                Response.End();
            }
            catch (Exception ex)
            {
                Response.End();
            }
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
    }
}

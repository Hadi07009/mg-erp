using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SINHA.MEDLAR.ERP.DBMANAGER
{
    public class QuertStringModule : System.Web.IHttpModule
    {
        static SymmetricAlgorithm mobjCryptoService;

        static QuertStringModule()
        {
            mobjCryptoService = new DESCryptoServiceProvider();
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Response.IsRequestBeingRedirected)
            {
                HttpContext.Current.Response.RedirectLocation = Encrypt(HttpContext.Current.Response.RedirectLocation);
            }
            else
            {
            }
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Url.ToString().Contains("?value"))
            {
                HttpContext.Current.RewritePath(Decrypt(HttpContext.Current.Request.Url.ToString()));
            }
            else if (HttpContext.Current.Request.Url.ToString().Contains("?"))
            {
                throw new HttpException("Not Valid Request");
            }
        }



        public static string Encrypt(string url)
        {
            if (url.Contains('?'))
            {
                url = url.Substring(0, url.IndexOf('?')) + "?value=" + Encrypting(url.Substring(url.IndexOf('?') + 1), "test");
            }
            return url;
        }

        public static string Decrypt(string url)
        {
            if (url.Contains("?value"))
            {
                string path = HttpContext.Current.Request.RawUrl;
                path = path.Substring(0, path.IndexOf("?") + 1);
                path = path.Substring(path.LastIndexOf("/") + 1);

                url = path + Decrypting(url.Substring(url.IndexOf('=') + 1), "test");
            }
            return url;
        }

        static string Encrypting(string Source, string Key)
        {
            byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(Source);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            byte[] bytKey = GetLegalKey(Key);

            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();

            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();

            byte[] bytOut = ms.GetBuffer();
            int i = 0;
            for (i = 0; i < bytOut.Length; i++)
                if (bytOut[i] == 0)
                    break;

            return System.Convert.ToBase64String(bytOut, 0, i);
        }

        static string Decrypting(string Source, string Key)
        {
            byte[] bytIn = System.Convert.FromBase64String(Source);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
            ms.Position = 0;

            byte[] bytKey = GetLegalKey(Key);

            mobjCryptoService.Key = bytKey;
            mobjCryptoService.IV = bytKey;

            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();

            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(cs);
            return sr.ReadToEnd();
        }

        static byte[] GetLegalKey(string Key)
        {
            string sTemp;
            if (mobjCryptoService.LegalKeySizes.Length > 0)
            {
                int lessSize = 0, moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;

                while (Key.Length * 8 > moreSize)
                {
                    lessSize = moreSize;
                    moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;
                }
                sTemp = Key.PadRight(moreSize / 8, ' ');
            }
            else
                sTemp = Key;


            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

    }
}

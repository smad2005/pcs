using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;



namespace Pcs
{

    public struct Resultstruct
    {
        //public string SiteAdress;
        public string DirectAdress;
    }

    public class Pcs
    {

        /// <summary>
        /// Формат во что сохраняем
        /// </summary>
        public enum FormatEnum
        {
            Png,
            JpgHq,
            JpgLq,
            Gif
        }

        /// <summary>
        /// Адрес скрипта
        /// </summary>
        private Uri FullUrl { get; set; }


        /// <summary>
        /// Тут хранятся куки
        /// </summary>
        private readonly CookieContainer cookieContaner = new CookieContainer();


        /// <summary>
        /// Получить содержимое куки
        /// </summary>
        public string GetCookie
        {
            get
            {
                var cookie = cookieContaner.GetCookies(FullUrl)["nkkrs_c"];
                return cookie != null ? cookie.Value : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly WebHeaderCollection headers = new WebHeaderCollection
        {
                                                      {"HTTP_USER_AGENT","Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1"},
                                                      {"HTTP_ACCEPT","text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"},
                                                      {"HTTP_ACCEPT_CHARSET", "windows-1251,utf-8;q=0.7,*;q=0.7"},
                                                      {"HTTP_CONNECTION", "keep-alive"},
                                                      {"HTTP_ACCEPT_ENCODING", "gzip,deflate,sdch"},
                                                      {"HTTP_ACCEPT_LANGUAGE", " ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4"}
         };


        private Pcs()
        {

            FullUrl = new Uri("http://tknkk.tk//upload.php");
        }

        /// <summary>
        /// С указанием куки
        /// </summary>
        /// <param name="cookievalue">nkkrs_c</param>
        public Pcs(string cookievalue)
            : this()
        {
            if (!String.IsNullOrEmpty(cookievalue))
            {
                cookieContaner.Add(new Cookie("nkkrs_c", cookievalue, "/", FullUrl.Host));
                cookieContaner.Add(new Cookie("nkkrs_s", cookievalue, "/", FullUrl.Host));
            }
        }

        private void AddFiled(StreamWriter sw, string input, string value, string bounboundary)
        {
            sw.WriteLine("--{0}", bounboundary);
            sw.WriteLine("Content-Disposition: form-data; name=\"{0}\"", input);
            sw.WriteLine();
            sw.WriteLine(value);
            sw.Flush();
        }




        /// <summary>
        /// Залитие картинки
        /// </summary>
        /// <param name="path2File">Исходный файл</param>
        /// <param name="format">В каком формате сохраним</param>
        /// <param name="ispublic">Публиковать для всех посетителей </param>
        /// <exception cref="InvalidDataException">Не правильное расширение</exception>
        /// <exception cref="FileNotFoundException">Не найден файл</exception>
        public Resultstruct SendPicture(string path2File, FormatEnum format, bool ispublic = true)
        {
           
            if (!File.Exists(path2File))
                throw new FileNotFoundException();
            var filename = Path.GetFileName(path2File);
            var ext = GetExtension(path2File);
         
            var formatsend = Formatsend(format);

            // http://ru.wikipedia.org/wiki/Multipart_form-data
            var bytes = File.ReadAllBytes(path2File); //картинка
            string boundary = Guid.NewGuid().ToString().Replace("-", "");

            var we = (HttpWebRequest)WebRequest.Create(FullUrl);
            const string inputfile = "fl"; // название input для отправки файла
            we.Headers = headers; //Заголовки
            we.Referer = String.Format("{0}://{1}/", FullUrl.Scheme, FullUrl.Host);
            we.CookieContainer = cookieContaner;
          
            we.Method = "Post";
            we.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);

            Resultstruct result; //Результат
            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms, Encoding.GetEncoding(1251)))
            {
                AddFiled(sw, "recompress", formatsend, boundary);  //формат сохранения
                AddFiled(sw, "pub", ispublic ? "on" : "", boundary); //публично ли всем

                sw.Write("--{0}\r\n", boundary);
                sw.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n", inputfile, filename);
                sw.Write("Content-Type: image/{0} \r\n\r\n", ext);
                sw.Flush();
                ms.Write(bytes, 0, bytes.Length);
                sw.Write("\r\n--{0}--\r\n", boundary);
                sw.Flush();
                we.ContentLength = ms.Length;

                using (var rs = we.GetRequestStream())
                {
                    ms.WriteTo(rs);
                    result = Resultstruct(we);
                }
            }
            return result;
        }

        private static Resultstruct Resultstruct(HttpWebRequest we)
        {
            Resultstruct result;
            using (var rsp = we.GetResponse().GetResponseStream())
            using (var sr = new StreamReader(rsp, Encoding.GetEncoding(1251)))
            {
                string res = sr.ReadToEnd();
                var regex = new Regex("(" + we.Referer + @"f/.*?)\[", RegexOptions.Singleline | RegexOptions.Compiled);
                if (regex.Match(res).Groups[1].Success)
                {
                    result.DirectAdress = regex.Match(res).Groups[1].Value;
                    //result.SiteAdress = result.DirectAdress.Replace("/f/", "/");
                }
                else
                {
                    throw new InvalidOperationException("Can't find address of picture");
                }
            }
            // Console.WriteLine(res);
            //0363d52dcc0bae39e3627af5de7f05a8"
            return result;
        }

        private static string Formatsend(FormatEnum format)
        {
            string formatsend = null;
            switch (format)
            {
                case FormatEnum.Gif:
                    formatsend = "gif";
                    break;
                case FormatEnum.JpgHq:
                    formatsend = "jhi";
                    break;
                case FormatEnum.JpgLq:
                    formatsend = "jlo";
                    break;
                case FormatEnum.Png:
                    formatsend = "png";
                    break;
            }
            return formatsend;
        }

        private static string GetExtension(string path2File)
        {
            string ext = Path.GetExtension(path2File).Remove(0, 1).ToLower();
            switch (ext)
            {
                case "jpg":
                    ext = "jpeg";
                    goto case "jpeg";
                case "gif":
                case "png":
                case "jpeg":
                    {
                        break;
                    }
                default:
                    throw new InvalidDataException("Wrong extension");
            }
            return ext;
        }
    }


}
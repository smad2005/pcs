using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace Pcs
{
   public class  Register
   {
       private readonly string path;
       private const string REGNAME = "topcs";

       public Register()
       {
           
       }
       public Register(string path2Application)
       {
           path = Path.GetFullPath(path2Application);
       }

       /// <summary>
       ///Добавляет в контексное меню
       /// Важен путь  к ехе
       /// </summary>
       ///<exception cref="ArgumentNullException">Не указан путь, используйте другой конструктор</exception>
       public void AddToContextMenu()
       {
            if (String.IsNullOrEmpty(path))
               throw new ArgumentNullException("Path not found");
           var shell=Registry.ClassesRoot.OpenSubKey(@"\*\shell\", true);
           if (shell != null)
           {
               var topcs=shell.CreateSubKey(REGNAME);
               topcs.SetValue("", "Залить на img.a2me");
               topcs.SetValue("Icon",string.Format("\"{0}\"",path));
               topcs.CreateSubKey("Command").SetValue("", string.Format("\"{0}\" -a \"%1\"", path));
           }
       }

       /// <summary>
       /// Удаляет из контексного меню
       /// Путь к ехе не важен
       /// </summary>
       public void RemoveFromContextMenu()
       {
           var shell = Registry.ClassesRoot.OpenSubKey(@"\*\shell\", true);
           shell.DeleteSubKeyTree(REGNAME);
       }
   }

 
}

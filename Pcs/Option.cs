using System;
using System.IO;

using System.Xml.Serialization;

namespace Pcs
{
    [Serializable]
    public sealed class Option
    {

        [NonSerialized]
        private static string filename;

        /// <summary>
        /// Путь к настройкам
        /// </summary>
        [XmlIgnore]
        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }

        /// <summary>
        ///Для куки nkkrs_c
        /// </summary>
        public string Cookievalue { set; get; }

        /// <summary>
        ///Публиковать для всех посетителей
        /// </summary>
        public bool IsPublic { set; get; }


        /// <summary>
        /// В какой формате сохраняем
        /// Если не загрузится будет Png
        /// </summary>
        public Pcs.FormatEnum SaveFormat { set; get; }

        private Option()
        {
            if (Filename == default(string))
            {
                Filename = "config.xml";
            }

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Option(bool preload = true)
            : this()
        {
            if (preload)
                Load();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="filename">путь к настройкам</param>
        public Option(string filename)
        {

            Filename = filename;
            Load();
        }

        /// <summary>
        /// Сохранение настроек
        /// </summary>
        public void Save()
        {
            var xs = new XmlSerializer(typeof(Option));
            using (var fs = new FileStream(Filename, FileMode.Create))
            {
                xs.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Загрузка настроек
        /// </summary>
        private void Load()
        {
            var xs = new XmlSerializer(typeof(Option));
            using (var fs = new FileStream(Filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                try
                {
                    var opt = (Option)xs.Deserialize(fs);
                    if (opt != null)
                    {
                        Cookievalue = opt.Cookievalue;
                        SaveFormat = opt.SaveFormat;
                        IsPublic = opt.IsPublic;
                    }

                }
                catch (Exception)
                {
                }

            }
        }

    }
}

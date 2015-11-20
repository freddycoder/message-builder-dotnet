using System;
using System.Text;
using System.IO;
using System.Xml;

namespace Hello_World
{
    class ResourceUtil
    {
        public static string ReadResourceFile(string resourceName)
        {
            string contents = null;
            Stream stream = GetEmbeddedFile("Hello_World", resourceName);
            contents = ConvertStreamToString(stream);
            return contents;
        }


        public static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                return str;
            }
            catch (Exception e)
            {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }

        public static String ConvertStreamToString(Stream memStream)
        {
            /*
		     * To convert the InputStream to String we use the BufferedReader.readLine()
		     * method. We iterate until the BufferedReader return null which means
		     * there's no more data to read. Each line will appended to a StringBuilder
		     * and returned as String.
		     */
            if (memStream != null)
            {
                StringBuilder sb = new StringBuilder();
                String line;

                StreamReader reader = new StreamReader(memStream);

                while ((line = reader.ReadLine()) != null)
                {
                    sb.Append(line).Append("\n");
                }

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string Beautify(string text)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(text);

            return Beautify(document);
        }

        public static string Beautify(XmlDocument document)
        {

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            XmlWriter writer = XmlWriter.Create(sb, settings);
            document.Save(writer);
            writer.Close();
            return sb.ToString();
        }
    }
}

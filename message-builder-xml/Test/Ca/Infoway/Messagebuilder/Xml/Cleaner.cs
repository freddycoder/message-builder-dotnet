using System.IO;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	public class Cleaner
	{
		/// <exception cref="System.Exception"></exception>
		public static void Main(string[] args)
		{
			//		File file = new File("../message-builder-hl7v3-release-pcs_mr2007_v02_r02/src/main/resources/messageSet_v02_r02.xml");
			//		File file = new File("../message-builder-hl7v3-release-pcs_cerx_v01_r04_3/src/main/resources/messageSet_v01r04_3.xml");
			//		File file = new File("../message-builder-release-newfoundland/src/main/resources/messageSet_NEWFOUNDLAND.xml");
			//		File file = new File("../message-builder-hl7v3-release-pcs_mr2009_r02_04_02/src/main/resources/messageSet_r02_04_02.xml");
			FileInfo file = new FileInfo("../message-builder-xml-validation/src/test/resources/ca/infoway/messagebuilder/xml/validator/messageSet_v02r02.xml"
				);
			MessageSetMarshaller marshaller = new MessageSetMarshaller();
			MessageSet messageSet = marshaller.Unmarshall(file);
			marshaller.Marshall(messageSet, file);
		}
	}
}

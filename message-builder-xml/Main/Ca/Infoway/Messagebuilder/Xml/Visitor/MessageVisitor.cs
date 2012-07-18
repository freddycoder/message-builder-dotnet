using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Visitor
{
	public interface MessageVisitor
	{
		void VisitStructuralAttribute(XmlElement @base, XmlAttribute attr, Relationship relationship);

		void VisitAssociation(XmlElement @base, string xmlName, IList<XmlElement> elements, Relationship relationship);

		void VisitNonStructuralAttribute(XmlElement @base, IList<XmlElement> elements, Relationship relationship);

		void VisitRoot(XmlElement documentElement, Interaction interaction);
	}
}

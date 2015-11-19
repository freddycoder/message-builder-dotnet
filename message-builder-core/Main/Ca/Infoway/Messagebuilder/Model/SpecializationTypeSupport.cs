using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Model
{
	public interface SpecializationTypeSupport
	{
		StandardDataType GetSpecializationType(string propertyName);

		void SetSpecializationType(string propertyName, StandardDataType specializationType);

		StandardDataType GetSpecializationTypeInList(string propertyName, int indexInList);

		bool SetSpecializationTypeInList(string propertyName, int indexInList, StandardDataType specializationType);

		StandardDataType GetSpecializationTypeInSet(string propertyName, object valueInSet);

		bool SetSpecializationTypeInSet(string propertyName, object valueInSet, StandardDataType specializationType);
	}
}

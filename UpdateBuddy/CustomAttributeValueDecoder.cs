using System.Reflection.Metadata;

namespace UpdateBuddy;

public class CustomAttributeValueDecoder : ICustomAttributeTypeProvider<object>
{
    public object GetPrimitiveType(PrimitiveTypeCode typeCode)
    {
        return typeCode;
    }

    public object GetSystemType()
    {
        return typeof(object);
    }

    public object GetSZArrayType(object elementType)
    {
        return elementType;
    }

    public object GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
    {
        TypeDefinition typeDef = reader.GetTypeDefinition(handle);
        string name = reader.GetString(typeDef.Name);
        string namespaceName = reader.GetString(typeDef.Namespace);
        return $"{namespaceName}.{name}";
    }

    public object GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
    {
        TypeReference typeRef = reader.GetTypeReference(handle);
        string name = reader.GetString(typeRef.Name);
        string namespaceName = reader.GetString(typeRef.Namespace);
        return $"{namespaceName}.{name}";
    }

    public bool IsSystemType(object type)
    {
        return type is Type sType && sType == typeof(Type);
    }

    public object GetTypeFromSerializedName(string name)
    {
        return name;
    }

    public PrimitiveTypeCode GetUnderlyingEnumType(object type)
    {
        return PrimitiveTypeCode.Int32;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;

namespace Databvase_Winforms.Extensions
{
    public static class SMODataTypeExtensions
    {
        /// <summary>
        /// Indicates whether the type is a Bit/Boolean or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsBit(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.Bit;
        }

        /// <summary>
        /// Indicates whether the type is a DateTime type or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsDateTimeType(this DataType dataType)
        {
            bool isDateTime = false;

            switch (dataType.SqlDataType)
            {
                case SqlDataType.Date:
                case SqlDataType.DateTime:
                case SqlDataType.DateTime2:
                case SqlDataType.DateTimeOffset:
                case SqlDataType.SmallDateTime:
                case SqlDataType.Time:
                    isDateTime = true;
                    break;
                default:
                    break;
            }

            return isDateTime;
        }

        /// <summary>
        /// Indicates whether the type is rowversion/TimeStamp type or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsRowVersion(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.Timestamp;

        }

        /// <summary>
        /// Indicates whether the type is a Binary type or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsBinary(this DataType dataType)
        {
            bool isBinary = false;


            switch (dataType.SqlDataType)
            {
                case SqlDataType.Binary:
                case SqlDataType.VarBinary:
                case SqlDataType.VarBinaryMax:
                case SqlDataType.Image:
                    isBinary = true;
                    break;
            }

            return isBinary;
        }

        /// <summary>
        /// Indicates whether the type is a Unique Identifier / GUID type or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsUniqueIdentifier(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.UniqueIdentifier;

        }

        /// <summary>
        /// Indicates whether the type is XML or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsXML(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.Xml;
        }

        /// <summary>
        /// Indicates whether type is a Spatial type (Geometry or Geography) or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsSpatial(this DataType dataType)
        {
            bool isSpatial = false;

            switch (dataType.SqlDataType)
            {
                case SqlDataType.Geography:
                case SqlDataType.Geometry:
                    isSpatial = true;
                    break;
            }

            return isSpatial;
        }

        /// <summary>
        /// Indicates whether type is a SysName or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsSysName(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.SysName;
        }

        /// <summary>
        /// Indicates whether type is a Sql Variant or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsSqlVariant(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.Variant;
        }

        /// <summary>
        /// Indicates whether type is User Defined or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsUserDefined(this DataType dataType)
        {
            bool isUserDefined = false;

            switch (dataType.SqlDataType)
            {
                case SqlDataType.UserDefinedDataType:
                case SqlDataType.UserDefinedTableType:
                case SqlDataType.UserDefinedType:
                    isUserDefined = true;
                    break;
            }

            return isUserDefined;
        }

        /// <summary>
        /// Indicates whether type is a Hierarchy Id or not.
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static bool IsHierarchyId(this DataType dataType)
        {
            return dataType.SqlDataType == SqlDataType.HierarchyId;
        }
    }
}

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace CodeFirstWithDb_POCOGen
{

    // Region
    public class Region
    {
        public int RegionId { get; set; } // RegionID (Primary key)
        public string RegionDescription { get; set; } // RegionDescription (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Territories where [Territories].[RegionID] point to this entity (FK_Territories_Region)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Territory> Territories { get; set; } // Territories.FK_Territories_Region

        public Region()
        {
            Territories = new System.Collections.Generic.List<Territory>();
        }
    }

}
// </auto-generated>

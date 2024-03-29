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

    // Current Product List
    public class CurrentProductListConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CurrentProductList>
    {
        public CurrentProductListConfiguration()
            : this("dbo")
        {
        }

        public CurrentProductListConfiguration(string schema)
        {
            ToTable("Current Product List", schema);
            HasKey(x => new { x.ProductId, x.ProductName });

            Property(x => x.ProductId).HasColumnName(@"ProductID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType("nvarchar").IsRequired().HasMaxLength(40).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }

}
// </auto-generated>

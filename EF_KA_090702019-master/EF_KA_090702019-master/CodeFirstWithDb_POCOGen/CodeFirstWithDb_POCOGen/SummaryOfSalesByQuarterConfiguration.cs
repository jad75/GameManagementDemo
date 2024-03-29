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

    // Summary of Sales by Quarter
    public class SummaryOfSalesByQuarterConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SummaryOfSalesByQuarter>
    {
        public SummaryOfSalesByQuarterConfiguration()
            : this("dbo")
        {
        }

        public SummaryOfSalesByQuarterConfiguration(string schema)
        {
            ToTable("Summary of Sales by Quarter", schema);
            HasKey(x => x.OrderId);

            Property(x => x.ShippedDate).HasColumnName(@"ShippedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.OrderId).HasColumnName(@"OrderID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Subtotal).HasColumnName(@"Subtotal").HasColumnType("money").IsOptional().HasPrecision(19,4);
        }
    }

}
// </auto-generated>

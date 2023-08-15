using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Configuries.Base;
using CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnD.CommunalPayments3.Back.DataLayer.Infrastructure.Configuries;

public class InvoiceConfigure : BaseEntityConfigure, IEntityTypeConfiguration<InvoiceEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceEntity> builder)
    {
        builder.ToTable("Invoices");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.IsPaid).HasColumnName("is_paid").HasDefaultValue(false);
        builder.Property(x => x.ProviderId).HasColumnName("provider_id");
        builder.Property(x => x.PeriodId).HasColumnName("period_id");

        builder.HasOne(x=>x.Period).WithMany().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Provider).WithMany().OnDelete(DeleteBehavior.NoAction);
    }
}

public class InvoiceServiceConfigure : BaseEntityConfigure, IEntityTypeConfiguration<InvoiceServicesEntity>
{
    public void Configure(EntityTypeBuilder<InvoiceServicesEntity> builder)
    {
        builder.ToTable("InvoiceServices");

        builder.Property(x => x.InvoiceId).HasColumnName("InvoiceId");
        builder.Property(x => x.ServiceId).HasColumnName("ServiceId");
        builder.Property(x => x.Amount).HasColumnName("Amount");

        builder.HasOne(x => x.Invoice);
        builder.HasOne(x => x.Service);
    }
}

public class OrderConfigure : BaseEntityConfigure, IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");

        builder.Property(x => x.FileName).HasColumnName("FileName");
        builder.Property(c => c.OrderScreen).HasColumnName("OrderScreen");
    }
}

public class PaymentConfigure : BaseEntityConfigure, IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.ToTable("Payments");

        builder.Property(x => x.DatePayment).HasColumnName("DatePayment");
        builder.Property(x => x.PaymentSum).HasColumnName("PaymentSum");
        builder.Property(x => x.InvoiceId).HasColumnName("InvoiceId");
        builder.Property(x => x.OrderId).HasColumnName("OrderId");
        builder.Property(x => x.Paid).HasColumnName("Paid");

        builder.HasOne(x => x.Invoice);
        builder.HasOne(x => x.Order).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}

public class ServiceCounterConfigure : BaseEntityConfigure, IEntityTypeConfiguration<ServiceCounterEntity>
{
    public void Configure(EntityTypeBuilder<ServiceCounterEntity> builder)
    {
        builder.ToTable("ServiceCounters");

        builder.Property(x => x.Value).HasColumnName("Value");
        builder.Property(x => x.DateCount).HasColumnName("DateCount");
        builder.Property(x => x.ServiceId).HasColumnName("ServiceId");

        builder.HasOne(x => x.Service);
    }
}

public class ServiceConfigure : BaseEntityConfigure, IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        builder.ToTable("Services");

        builder.Property(x => x.IsCounter).HasColumnName("IsCounter");
        builder.Property(x => x.Name).HasColumnName("ServiceName");
    }
}

public class PeriodConfigure : BaseEntityConfigure, IEntityTypeConfiguration<PeriodEntity>
{
    public void Configure(EntityTypeBuilder<PeriodEntity> builder)
    {
        builder.ToTable("Periods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");

        builder.Property(x => x.Month).HasColumnName("month").HasMaxLength(8);
        builder.Property(x => x.Year).HasColumnName("year").HasMaxLength(4);
    }
}

public class ProviderConfigure : IEntityTypeConfiguration<ProviderEntity>
{
    public void Configure(EntityTypeBuilder<ProviderEntity> builder)
    {
        builder.ToTable("Providers");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        
        builder.Property(x => x.NameProvider).HasColumnName("name_provider");
        builder.Property(x => x.WebSite).HasColumnName("website");
    }
}
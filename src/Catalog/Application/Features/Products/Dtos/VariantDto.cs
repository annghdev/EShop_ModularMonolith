namespace Catalog.Application;

public record VariantDto(
    Guid Id,
    string? Name,
    string Sku,
    MoneyDto OverrideCost,
    MoneyDto OverridePrice,
    DimensionsDto Dimensions
    );
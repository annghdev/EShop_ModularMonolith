using Kernel.Domain;

namespace Kernel.Application;

public static class ValueOnjectMapping
{
    public static Money ToMoney(this MoneyDto dto)
        => new(dto.Amount, dto.Currency);
    public static MoneyDto ToMoneyDto(this Money money)
        => new(money.Amount, money.Currency);

    public static Dimensions ToDimensions(this DimensionsDto dto)
        => new(dto.Width, dto.Height, dto.Depth, dto.Weight);
    public static DimensionsDto ToDimensionsDto(this Dimensions dimensions)
        => new(dimensions.Width, dimensions.Height, dimensions.Depth, dimensions.Weight);
}
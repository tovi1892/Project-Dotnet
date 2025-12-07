


using System;
using System.Diagnostics;

namespace DO;

public record Sale(
    int SaleId,
int ProductId,
    int QuantityToSale,
    int TotalPrice,
    bool IsClube,
    DateTime StartSale,
    DateTime EndSale
    )
{
}

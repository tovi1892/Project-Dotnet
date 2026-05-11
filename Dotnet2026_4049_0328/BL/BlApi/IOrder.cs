using System.Collections.Generic;

using System.Collections.Generic;
using BO;

namespace BL.BlApi;

public interface IOrder
{
    List<ProductInOrder> AddProductToOrder(Order order, int productId, int quantity);
    void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    void CalcTotalPrice(Order order);
    void DoOrder(Order order);
    void SearchSaleForProduct(ProductInOrder productInOrder, bool isPreferredClient);
}

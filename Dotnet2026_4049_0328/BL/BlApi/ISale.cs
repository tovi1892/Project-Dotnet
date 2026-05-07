
using System;
using System.Collections.Generic;
using BO;

namespace BL.BlApi;

public interface ISale
{
    int Create(Sale item);
    Sale? Read(int id);
    Sale? Read(Func<Sale, bool> filter);
    List<Sale> ReadAll(Func<Sale, bool>? filter = null);
    void Update(Sale item);
    void Delete(int id);
}
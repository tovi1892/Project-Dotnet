using DO;
using DalApi;

namespace Dal;

internal class SaleDalXml : ISale
{
    readonly string s_path = @"xml\sales.xml";

    public int Create(Sale item)
    {
        List<Sale> list = XMLTools.LoadListFromXmlSerializer<Sale>(s_path);
        int nextId = Config.SaleNum;

        Sale newItem = item with { SaleId = nextId }; // יצירת עותק עם ה-ID החדש
        list.Add(newItem);

        XMLTools.SaveListToXmlSerializer(list, s_path);
        return nextId;
    }

    public Sale? Read(int id) =>
        XMLTools.LoadListFromXmlSerializer<Sale>(s_path).FirstOrDefault(s => s.SaleId == id);

    public Sale? Read(Func<Sale, bool> filter) =>
        XMLTools.LoadListFromXmlSerializer<Sale>(s_path).FirstOrDefault(filter);

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        List<Sale> list = XMLTools.LoadListFromXmlSerializer<Sale>(s_path);
        return filter == null ? list : list.Where(filter).ToList();
    }

    public void Update(Sale item)
    {
        List<Sale> list = XMLTools.LoadListFromXmlSerializer<Sale>(s_path);
        int index = list.FindIndex(s => s.SaleId == item.SaleId);

        if (index == -1) throw new Exception("Sale not found");

        list[index] = item;
        XMLTools.SaveListToXmlSerializer(list, s_path);
    }

    public void Delete(int id)
    {
        List<Sale> list = XMLTools.LoadListFromXmlSerializer<Sale>(s_path);
        Sale? item = list.FirstOrDefault(s => s.SaleId == id);

        if (item == null) throw new Exception("Sale not found");

        list.Remove(item);
        XMLTools.SaveListToXmlSerializer(list, s_path);
    }
}
using System;
using ElectroShop;
using ElectroShopApi.Extensions;
using ElectroShopDB;

namespace ElectroShopApi
{
    public class ManufacturerMapper
    {
        public static Manufacturer Map(ManufacturerTable table)
        {
            return new Manufacturer(Name: table.Name, Country: table.Country)
            { Id = table.Id.ToGuid() };
        }
    }
}

namespace Pizza.Mappers
{
    public static class EnumMappers
    {
        public static Entities.EPizzaStockStatus ToEntityStatus(this Models.EPizzaStockStatus? status)
        {
            return status switch
            {
                Models.EPizzaStockStatus.In => Entities.EPizzaStockStatus.In,
                _ => Entities.EPizzaStockStatus.Out,
            };
        }

        public static Models.EPizzaStockStatus ToReturnedPizzaStatus(this Entities.EPizzaStockStatus stockStatus)
        {
            return stockStatus switch
            {
                Entities.EPizzaStockStatus.In => Models.EPizzaStockStatus.In,
                _ => Models.EPizzaStockStatus.Out 
            };
        }
    }
}
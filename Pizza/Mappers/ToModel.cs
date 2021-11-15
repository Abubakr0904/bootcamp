namespace Pizza.Mappers
{
    public static class ToModel
    {
        public static Models.ReturnedPizza FromPizzaEntityToModel(this Entities.Pizza pizza)
        {
            return new Models.ReturnedPizza()
            {
                Id = pizza.Id,
                Title = pizza.Title,
                ShortName = pizza.ShortName,
                Status = pizza.StockStatus.ToReturnedPizzaStatus(),
                Ingredients = pizza.Ingredients,
                Price = pizza.Price
            };
        } 
    }
}
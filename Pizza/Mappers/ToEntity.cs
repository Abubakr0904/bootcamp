using Pizza.Entities;
using Pizza.Mappers;

namespace Pizza.Mappers
{
    public static class ToEntity
    {
        public static Entities.Pizza FromPizzaModelToPizzaEntity(this Models.Pizza pizza)
        {
            return new Entities.Pizza(
                title: pizza.Title,
                shortName: pizza.ShortName,
                stockStatus: pizza.Status.ToEntityStatus(),
                ingredients: pizza.Ingredients,
                price: pizza.Price
            );
        }

        public static Entities.Pizza FromUpdatedPizzaModelToPizzaEntity(this Models.UpdatedPizza pizza)
        {
            return new Entities.Pizza(
                title: pizza.Title,
                shortName: pizza.ShortName,
                stockStatus: pizza.Status.ToEntityStatus(),
                ingredients: pizza.Ingredients,
                price: pizza.Price
            )
            {
                Id = pizza.Id
            };
        }
    }
}
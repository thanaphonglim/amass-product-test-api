using AmassTest.Application.Features.Products.CreateProduct;
using AmassTest.Application.Features.Products.DeleteProduct;
using AmassTest.Application.Features.Products.GetProducts;

namespace AmassTest.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static RouteGroupBuilder MapProductEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (
                CreateProductCommand command,
                CreateProductHandler handler) =>
            {
                await handler.Handle(command);
                return Results.Ok();
            });

            group.MapGet("/", async (
                GetProductsHandler handler) =>
            {
                return await handler.Handle();
            });

            group.MapDelete("/{id}", async (
                int id,
                DeleteProductHandler handler) =>
            {
                await handler.Handle(id);
                return Results.NoContent();
            });

            return group;
        }
    }
}

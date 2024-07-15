namespace ShoppingCartApplication
{
    public interface IStore
    {
        void FillProducts(int numberOfProducts);
        void DisplayProducts();
        Product GetProductByNumber(int productNumber);
    }
}

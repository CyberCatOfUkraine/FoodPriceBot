namespace PL.ProductActions
{
    public interface IProductAction
    {
        string Name { get; set; }
        void Action();
    }
}
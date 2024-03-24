namespace VendingMachine_Business.Interfaces
{
    internal class LookUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShelfView shelfView;

        public LookUseCase(IProductRepository productRepository, IShelfView shelfView)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}

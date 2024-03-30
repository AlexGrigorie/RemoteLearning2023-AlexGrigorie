namespace VendingMachine_Business.Interfaces
{
    internal class LookUseCase : IUseCase
    {
        private const string customMessageLookUseCase = "The user is searching for a product.";
        private readonly IProductRepository productRepository;
        private readonly IShelfView shelfView;
        private readonly ILoggerService loggerService;

        public LookUseCase(IProductRepository productRepository, IShelfView shelfView, ILoggerService loggerService)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }

        public void Execute()
        {
            loggerService.LogInformation(customMessageLookUseCase);
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}

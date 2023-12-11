using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Helper;
using iQuest.VendingMachine.Interfaces;
using System;
namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IVendingMachineApplication application;
        private readonly IBuyView buyView;
        private readonly IProductRepository productRepository;
        public string Name => "buy";

        public string Description => "Buy your favourite product";

        public bool CanExecute => !application.UserIsLoggedIn;

        public BuyUseCase(IVendingMachineApplication application, IBuyView buyView, IProductRepository productRepository)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            int productId = buyView.RequestProduct();

            if (productId == StatusProduct.CancelBuyProduct) throw new CancelException();

            Product product = productRepository.GetByColumn(productId);
            if (product == null)
            {
                throw new InvalidColumnException();
            }
            if (product.Quantity >= StatusProduct.SufficientStock)
            {
                product.Quantity--;
                buyView.DispenseProduct(product.Name);
            }
            else
            {
                throw new InsufficientStockException();
            }
        }
    }
}

using iQuest.VendingMachine.Entities;
using iQuest.VendingMachine.Exceptions;
using iQuest.VendingMachine.Helper;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using System;
namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly VendingMachineApplication application;
        private readonly BuyView buyView;
        private readonly ProductRepository productRepository;
        public string Name => "buy";

        public string Description => "Buy your favourite product";

        public bool CanExecute => !application.UserIsLoggedIn;

        public BuyUseCase(VendingMachineApplication application, BuyView buyView, ProductRepository productRepository)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void Execute()
        {
            int productId = buyView.RequestProduct();
            try
            {
                if (productId == StatusProduct.CancelBuyProduct) throw new CancelException();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
                return;
            }
            try
            {
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
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex);
            }
        }
    }
}

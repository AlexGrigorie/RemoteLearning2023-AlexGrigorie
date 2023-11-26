using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly ProductRepository productRepository;
        private readonly ShelfView shelfView;
        public string Name => "look";

        public string Description => "Display all available products.";

        public bool CanExecute => true;

        public LookUseCase( ProductRepository productRepository, ShelfView shelfView)
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

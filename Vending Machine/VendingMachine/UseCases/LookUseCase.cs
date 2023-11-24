using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Repository;
using iQuest.VendingMachine.View;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly ProductRepository productRepository;
        private readonly VendingMachineApplication application;
        private readonly MainDisplay mainDisplay;
        private readonly ShelfView shelfView;
        public string Name => "look";

        public string Description => "Display all available products.";

        public bool CanExecute => true;

        public LookUseCase(VendingMachineApplication application, MainDisplay mainDisplay, ProductRepository productRepository, ShelfView shelfView)
        {
            this.application = application ?? throw new ArgumentNullException(nameof(application));
            this.mainDisplay = mainDisplay ?? throw new ArgumentNullException(nameof(mainDisplay));
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            shelfView.DisplayProducts(productRepository.GetAll());
        }
    }
}

using Layer.Factory.Domain;
using Layer.Factory.Process;

namespace Layer.Factory
{
    using Layer.Factory.Presentation;

    using NUnit.Framework;

    [TestFixture]
    public class Application
    {
        private LayerProductionView view;

        private LayerProductionPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            this.view = new LayerProductionView();
            this.presenter = new LayerProductionPresenter(this.view, new LayerProductionApplicationService(new FactoryDomainService(new FactoryRepository()), new LayerDomainService(new LayerRepository())));
            this.presenter.Initialize();
        }

        [Test]
        public void Run()
        {
            this.view.ClickOpenFactory();
            this.view.ClickProduceLayer();
        }
    }
}
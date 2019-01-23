using RedWood.Attributes;

namespace RedWood
{
    internal class TreeListController
    {
        private ITreeListView _view;
        private object _viewModel;

        public TreeListController(ITreeListView view)
        {
            _view = view;
        }

        private void DisplayObject()
        {
            _view.DisplayObject(_viewModel);
        }

        public void SetObject(object o)
        {
            _viewModel = o;
            DisplayObject();
        }
    }
}
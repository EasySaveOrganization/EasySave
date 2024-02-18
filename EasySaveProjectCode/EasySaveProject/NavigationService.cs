using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EasySaveProject
{
    class NavigationService : INavigationService
    {
        //a dictionary to hold the maping of string keys to pag creation
        private readonly Dictionary<string, Func<Page>> _pagesByKey;
        private readonly Frame _mainFrame;

        //constructor
        public NavigationService(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            _pagesByKey = new Dictionary<string, Func<Page>>();
        }

        //method to navigate to a page using its key
        public void NavigateTo(string pageKey)
        {
            if (_pagesByKey.TryGetValue(pageKey, out var createPage))
            {
                var page = createPage();
                _mainFrame.Navigate(page);
            }
            else
            {
                throw new ArgumentException($"No page found for key {pageKey}", nameof(pageKey));
            }
        }

        //method to register a page with its creation function using a key
        public void RegisterPage(string pageKey, Func<Page> createPageFunc)
        {
            _pagesByKey[pageKey] = createPageFunc;
        }
    }
}

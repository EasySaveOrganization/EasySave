using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EasySaveProject
{
    class NavigationService : INavigationService
    {
        //a dictionary to hold the maping of string keys to pag creation
        private readonly Dictionary<string, Func<UserControl>> _pagesByKey;
        private readonly Frame _mainFrame;

        //constructor
        public NavigationService(Frame mainFrame)
        {
            _mainFrame = mainFrame;
            _pagesByKey = new Dictionary<string, Func<UserControl>>();
        }

        //method to navigate to a page using its key
        public void NavigateTo(string pageKey)
        {
            //check if the page key exists in the dictionary
            if (_pagesByKey.TryGetValue(pageKey, out var createPageFunc))
            {
                var page = createPageFunc.Invoke();
                _mainFrame.Navigate(page);
            }
            else
            {
                throw new ArgumentException($"No page found for key {pageKey}", nameof(pageKey));
            }
        }

        //method to register a page with its creation function using a key
        public void RegisterPage(string pageKey, Func<UserControl> createPageFunc)
        {
            //add the key to the dictionary
            _pagesByKey[pageKey] = createPageFunc;
        }
    }
}

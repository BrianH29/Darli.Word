using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace Darli.Word
{
    public partial class WindowViewModel : ObservableObject
    {
        #region Private Member

        private Window _window;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer _windowResizer;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// minimum width window could be resize to 
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// minimum height window could be resize to 
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// Resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// Page Content inner padding
        /// </summary>
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get => new GridLength(TitleHeight + ResizeBorder); }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            _window = window;
            _windowResizer = new WindowResizer(window);

            _window.StateChanged += (sender, e) =>
            {
                //Fire off events for all the properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            
        }
        #endregion

        #region Commands

        [RelayCommand]
        private void Minimize()
        {
            _window.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        private void Maximize()
        {
            _window.WindowState ^= WindowState.Maximized;
        }

        [RelayCommand]
        private void Close()
        {
            _window.Close();
        }

        [RelayCommand]
        private void Menu()
        {
            SystemCommands.ShowSystemMenu(_window, GetMousePosition());
        }
        #endregion

        #region Helper
        private Point GetMousePosition()
        {
            return _windowResizer.GetCursorPosition();
        }
        #endregion
    }
}

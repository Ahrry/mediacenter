using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mediacenter.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace mediacenter.ViewModels
{
    public class LayoutViewModel : WorkspaceViewModel
    {
        #region Champs

        readonly VideoRepository _videoRepository;

        #endregion

        #region Properties

        private ObservableCollection<Video> _videos;

        public ObservableCollection<Video> Videos
        {
            get { return _videos; }
            set
            {
                _videos = value;
                base.OnPropertyChanged("Videos");
            }
        }

        private Video _selectedVideo;

        public Video SelectedVideo
        {
            get { return _selectedVideo; }
            set
            {
                _selectedVideo = value;
                base.OnPropertyChanged("SelectedVideo");
            }
        }

        #endregion

        #region DataContext

        void LoadVideos()
        {
            Videos = new ObservableCollection<Video>(_videoRepository.Getvideos());
        }

        void LoadVideosByCategorie(int idCategorie)
        {
            Videos = new ObservableCollection<Video>(_videoRepository.Getvideos());
        }

        #endregion

        #region Commandes

        public ICommand AddVideoCommand { get; set; }

        private void AddVideo()
        {
            OpenFileDialog opd = new OpenFileDialog();
            if ((bool)opd.ShowDialog())
            {
                Video video = new Video();
                video.Libelle = opd.SafeFileName;
                video.FileName = opd.FileName;

                Videos.Add(video);

                SelectedVideo = video;
            }
        }

        public ICommand SaveCommand { get; set; }

        private void Save(object obj)
        {
            _videoRepository.Save();
        }

        #endregion

        #region Constructeur
        
        public LayoutViewModel()
        {
            _videoRepository = new VideoRepository();
            LoadVideos();

            AddVideoCommand = new RelayCommand(param => this.AddVideo());
            SaveCommand = new RelayCommand(param => this.AddVideo());
        } 

        #endregion
    }
}

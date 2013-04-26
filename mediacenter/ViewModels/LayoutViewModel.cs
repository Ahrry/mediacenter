using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mediacenter.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using mediacenter.Views;

namespace mediacenter.ViewModels
{
    public class LayoutViewModel : WorkspaceViewModel
    {
        #region Champs

        readonly VideoRepository _videoRepository;

        #endregion

        #region Properties

        private Type _type;

        public Type Type
        {
            get { return _type; }
            set 
            {
                _type = value;
                base.OnPropertyChanged("Type");
            }
        }

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

        private UserControl _detail;

        public UserControl Detail
        {
            get { return _detail; }
            set 
            { 
                _detail = value;
                base.OnPropertyChanged("Detail");
            }
        } 

        #endregion

        #region DataContext

        void LoadVideos()
        {
            if(Type != null)
                Videos = new ObservableCollection<Video>(_videoRepository.GetvideosParCategorie(Type.Id));
        }

        void LayoutViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedVideo")
            {
                switch (SelectedVideo.Type.Libelle)
                {
                    case "Films":
                        Detail = new DetailVide();
                        break;
                    default:
                        //Detail = null;
                        break;
                }
            }

            if (e.PropertyName == "Type")
            {
                switch (Type.Libelle)
                {
                    case "Films":
                        Detail = new DetailVide();
                        break;
                    default:
                        //Detail = null;
                        break;
                }
                LoadVideos();
            }
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
                video.Type = Type;

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

            AddVideoCommand = new RelayCommand(param => this.AddVideo());
            SaveCommand = new RelayCommand(param => this.AddVideo());

            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LayoutViewModel_PropertyChanged);
        }

        #endregion
    }
}

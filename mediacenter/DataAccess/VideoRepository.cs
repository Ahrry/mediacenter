using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace mediacenter.DataAccess
{
    class VideoRepository
    {        
        #region Entities

        private MediaCenterDBEntities entities = new MediaCenterDBEntities();

        #endregion

        #region Champs

        readonly ObjectSet<Video> _videos;

        #endregion

        #region Constructeur

        public VideoRepository()
        {
            _videos = entities.Videos;
        }

        #endregion

        #region DataAccess

        public IEnumerable<Video> Getvideos()
        {
            return _videos;
        }

        public IEnumerable<Video> GetvideosParCategorie(int idCategorie)
        {
            return _videos.Include("Type").Where(v => v.IdType == idCategorie);
        }

        #endregion

        #region Methodes

        public void Save()
        {
            entities.SaveChanges();
        }

        #endregion
    }
}

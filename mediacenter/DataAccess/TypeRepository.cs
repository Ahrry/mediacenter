using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace mediacenter.DataAccess
{
    public class TypeRepository
    {
        #region Entities

        private MediaCenterDBEntities entities = new MediaCenterDBEntities();

        #endregion

        #region Champs

        readonly ObjectSet<Type> _types;

        #endregion

        #region Constructeur

        public TypeRepository()
        {
            _types = entities.Types;
        }

        #endregion

        #region DataAccess

        public IEnumerable<Type> GetBaseCategories()
        {
            return _types.Where(t => t.TypeParentId == null);
        }

        #endregion
    }
}

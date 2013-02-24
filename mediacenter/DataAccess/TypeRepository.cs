using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mediacenter.DataAccess
{
    public class TypeRepository
    {
        #region Entities

        private MediaCenterDBEntities entities = new MediaCenterDBEntities();

        #endregion

        #region Champs

        readonly List<Type> _types;

        #endregion

        #region Constructeur

        public TypeRepository()
        {
            _types = entities.Types.ToList();
        }

        #endregion

        #region MyRegion

        public List<Type> GetBaseCategories()
        {
            return new List<Type>(_types.Where(t => t.TypeParentId == null));
        }

        #endregion
    }
}

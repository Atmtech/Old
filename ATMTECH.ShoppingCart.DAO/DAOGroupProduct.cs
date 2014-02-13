using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOGroupProduct : BaseDao<GroupProduct, int>, IDAOGroupProduct
    {
        public IDAOGroupUser DAOGroupUser { get; set; }

        public IList<GroupProduct> GetGroupProduct()
        {
            return GetAllActive();
        }

        public IList<GroupProduct> GetGroupProduct(Group group)
        {
            return GetAllOneCriteria(GroupProduct.GROUP, group.Id.ToString());
        }
        public IList<GroupProduct> GetGroupProduct(Product product)
        {
            return GetAllOneCriteria(GroupProduct.PRODUCT, product.Id.ToString());
        }

        public GroupProduct GetProductAccess(Product product, int idUser)
        {
            IList<GroupProduct> groupProducts = GetAllOneCriteria(GroupProduct.PRODUCT, product.Id.ToString());
            IList<Group> groups = DAOGroupUser.GetGroupByUser(idUser);
            IList<GroupProduct> validGroupProduct = (from groupProduct in groupProducts from @group in groups where groupProduct.Group.Id == @group.Id select groupProduct).ToList();
            return validGroupProduct.Count > 0 ? validGroupProduct[0] : new GroupProduct {IsRead = true, IsOrderable = false};
        }
    }
}

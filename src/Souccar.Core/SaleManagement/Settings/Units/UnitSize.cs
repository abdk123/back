using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Units
{
    public class UnitSize : Entity
    {
        public int Count { get; set; }

        #region Size
        public int? SizeId { get; set; }

        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        #endregion

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        #endregion
    }
}

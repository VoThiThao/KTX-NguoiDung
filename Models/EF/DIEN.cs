namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEN")]
    public partial class DIEN
    {
        [Key]
        public int MaDien { get; set; }

        [Required]
        [StringLength(15)]
        public string MaPhong { get; set; }

        public DateTime NgayGhi { get; set; }

        public int CSD { get; set; }

        public int CSC { get; set; }

        public double DonGia { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}

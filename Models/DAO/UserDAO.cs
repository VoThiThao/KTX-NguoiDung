using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO {
    public class UserDAO {
        private DBKTX db;

        public UserDAO() {
            db = new DBKTX();
        }
        public int login(string user, string pass, int chucVu) {
            var result = db.NGUOIDUNGs.SingleOrDefault(x => x.TenDangNhap.Contains(user) 
                && x.MatKhau.Contains(pass) && x.ChucVu==chucVu);
            if (result == null) {
                return 0;
            }
            else {
                return 1;
            }
        }

        public String Insert(NGUOIDUNG entityNguoiDung) {
            db.NGUOIDUNGs.Add(entityNguoiDung);
            db.SaveChanges();
            return entityNguoiDung.TenDangNhap;
        }

       public bool Update(NGUOIDUNG entityNguoiDung) {
           var user = db.NGUOIDUNGs.Select(x => x).Where(x => x.TenDangNhap == entityNguoiDung.TenDangNhap).FirstOrDefault();
            user.MatKhau = entityNguoiDung.MatKhau;
            user.MaNV = entityNguoiDung.MaNV;
            user.HoTenNV = entityNguoiDung.HoTenNV;
            user.ChucVu = entityNguoiDung.ChucVu;
            db.SaveChanges();
            return true;
        }

        public NGUOIDUNG getByTenDangNhap(string TenDangNhap) {
            return db.NGUOIDUNGs.SingleOrDefault(x => x.TenDangNhap == TenDangNhap);
        }

        public NGUOIDUNG Find(string tenDN) {
            return db.NGUOIDUNGs.Find(tenDN);
        }

        public List<NGUOIDUNG> ListAll()
        {
            return db.NGUOIDUNGs.ToList();
        }
        public List<NGUOIDUNG> ListWhereAll(string searchString) {
            if (!string.IsNullOrEmpty(searchString))
                return db.NGUOIDUNGs.Where(x => x.MaNV.Contains(searchString)).ToList();
            return db.NGUOIDUNGs.ToList();

        }

        public void Delete(string tenDangNhap) {
            try {

                var user = db.NGUOIDUNGs.FirstOrDefault(x => x.TenDangNhap.Contains(tenDangNhap));
                if (user != null) {
                    db.NGUOIDUNGs.Remove(user);
                    db.SaveChanges();
                }
            }
            
            catch (Exception e)
            {
                
            }
        }
    }
}


  

